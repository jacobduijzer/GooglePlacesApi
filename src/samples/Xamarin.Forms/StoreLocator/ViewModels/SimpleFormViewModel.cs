using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GooglePlacesApi;
using MvvmHelpers;
using Xamarin.Forms;
using GooglePlacesApi.Models;
using System.Collections.Generic;
using StoreLocator.Views;

namespace StoreLocator.ViewModels
{
    public class SimpleFormViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        private readonly GooglePlacesApiService _api;

        public SimpleFormViewModel(INavigation navigation)
        {
            _navigation = navigation;

            var settings = GoogleApiSettings.Builder.WithApiKey(Environment.GetEnvironmentVariable("GOOGLE_PLACES_API_KEY")).Build();

            _api = new GooglePlacesApiService(settings);
        }

        public ICommand DoSearchCommand
        => new Command(async () => await DoSearchAsync().ConfigureAwait(false), () => CanSearch);

        public ICommand SelectItemCommand
        => new Command<Prediction>(async (prediction) =>
        {
            await _navigation.PushAsync(new SimpleFormDetailPage(prediction.PlaceId, _api.GetSessionToken())).ConfigureAwait(false);
            _api.ResetSessionToken();
        });

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set 
            {
                if (SetProperty(ref _searchText, value))
                    OnPropertyChanged("CanSearch");
            }
        }

        private int _resultCount;
        public int ResultCount
        {
            get => _resultCount;
            set => SetProperty(ref _resultCount, value);
        }

        private List<Prediction> _results;
        public List<Prediction> Results
        {
            get => _results;
            set => SetProperty(ref _results, value);
        }

        public bool CanSearch => !string.IsNullOrWhiteSpace(SearchText) && SearchText.Length > 2;
        public bool HasResults => ResultCount > 0;

        private async Task DoSearchAsync()
        {
            var results = await _api.GetPredictionsAsync(SearchText)
                                    .ConfigureAwait(false);

            
            if(results != null && results.Status.Equals("OK"))
            {
                ResultCount = results.Items.Count;
                Results = results.Items;
                OnPropertyChanged("HasResults");
            }
        }
    }
}