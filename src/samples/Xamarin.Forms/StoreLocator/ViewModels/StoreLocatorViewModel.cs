using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GooglePlacesApi;
using GooglePlacesApi.Interfaces;
using GooglePlacesApi.Models;
using MvvmHelpers;
using Nito.AsyncEx;
using StoreLocator.Models;
using StoreLocator.Repositories;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoreLocator.ViewModels
{
    public class StoreLocatorViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        private readonly IGooglePlacesApiService _api;

        private readonly StoreRepository _storeRepository;

        public StoreLocatorViewModel(INavigation navigation)
        {
            _navigation = navigation;

            var settings = GoogleApiSettings.Builder.WithApiKey(Environment.GetEnvironmentVariable("GOOGLE_PLACES_API_KEY")).Build();
            _api = new GooglePlacesApiService(settings);

            _storeRepository = new StoreRepository();

            Task.Run(async () => await GetLocationAndStoresAsync());
            
            SetupObservables();
        }

        private async Task GetLocationAndStoresAsync()
        {
            try
            {
                var location = Geolocation.GetLastKnownLocationAsync().Result;

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync();
                }

                if (location != null)
                {
                    CurrentLocation = location;

                    Stores = _storeRepository.GetAll().OrderBy(x => x.Name)
                                             .Select(x => new PresentableStore(x, location.Latitude, location.Longitude))
                                             .ToList();
                }
                else
                {
                    Stores = _storeRepository.GetAll().OrderBy(x => x.Name)
                                                 .Select(x => new PresentableStore(x))
                                                 .ToList();
                }

            }
            catch (Exception ex)
            {
                Stores = _storeRepository.GetAll().OrderBy(x => x.Name)
                                             .Select(x => new PresentableStore(x))
                                             .ToList();
            }


        }
                
        public ICommand SelectGoogleItemCommand
        => new Command<Prediction>(async (Prediction item) => await DoSelectItem(item).ConfigureAwait(false));

        #region Properties

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        private List<PresentableStore> _stores;
        public List<PresentableStore> Stores
        {
            get => _stores;
            set 
            {
                SetProperty(ref _stores, value);
                Height = (value.Count * 40);
                OnPropertyChanged();
            }
        }

        private List<Prediction> _googleSearchResult = new List<Prediction>();
        public List<Prediction> GoogleSearchResult
        {
            get { return _googleSearchResult; }
            set
            {
                if(SetProperty(ref _googleSearchResult, value))
                {
                    OnPropertyChanged("GoogleSearchResult");
                    OnPropertyChanged("HasResults");    
                }
            }
        }

        private Xamarin.Essentials.Location _currentLocation;
        public Xamarin.Essentials.Location CurrentLocation
        {
            get => _currentLocation;
            set => SetProperty(ref _currentLocation, value);
        }

        private Prediction _selectedGoogleLocation;
        public Prediction SelectedGoogleLocation
        {
            get => _selectedGoogleLocation;
            set => SetProperty(ref _selectedGoogleLocation, value);
        }

        private double _height;
        public double Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        public bool HasResults => GoogleSearchResult != null && GoogleSearchResult.Any();

        private IDisposable _throttledTyping;

        private bool _disableSearch;

        private CancellationTokenSource _cancellationTokenSource;

        #endregion

        private void SetupObservables()
        {
            var scheduler = Scheduler.Default;

            var viewModelChanged = Observable.FromEventPattern<PropertyChangedEventArgs>(this, "PropertyChanged");

            _throttledTyping = viewModelChanged.Where(e => e.EventArgs.PropertyName == nameof(SearchText))
                                               .Throttle(TimeSpan.FromSeconds(.1), scheduler)
                                               .Subscribe(async (e) => await FilterOnLocation().ConfigureAwait(false));
        }

        private async Task FilterOnLocation()
        {
            if (_disableSearch)
            {
                _disableSearch = false;
                return;
            }

            if (string.IsNullOrEmpty(SearchText))
            {
                GoogleSearchResult = new List<Prediction>();
                await GetLocationAndStoresAsync().ConfigureAwait(false);
            }
            else
            {
                var result = await _api.GetPredictionsAsync(SearchText)
                                       .ConfigureAwait(false);

                if (result != null && result.Status.Equals("OK") && result.Items != null)
                    GoogleSearchResult = result.Items;
            }
        }

        private async Task DoSelectItem(Prediction item)
        { 
            _disableSearch = true;
            SelectedGoogleLocation = item;
            GoogleSearchResult = new List<Prediction>();
            _searchText = item.Description;
            OnPropertyChanged("SearchText");

            var details = await _api.GetDetailsAsync(item.PlaceId, _api.GetSessionToken())
                                    .ConfigureAwait(false);

            if(details != null)
            {
                Stores = _storeRepository.GetSortedStores(details.Place.Geometry.Location)
                                         .Select(x => new PresentableStore(x, 
                                                                           details.Place.Geometry.Location.Latitude, 
                                                                           details.Place.Geometry.Location.
                                                                           Longitude))
                                         .ToList();
            }
        }
    }
}
