using System;
using System.Threading.Tasks;
using GooglePlacesApi;
using GooglePlacesApi.Models;
using MvvmHelpers;
using Nito.AsyncEx;

namespace StoreLocator.ViewModels
{
    public class SimpleFormDetailViewModel : BaseViewModel
    {
        private readonly string _placeId;

        private readonly GooglePlacesApiService _api;

        public SimpleFormDetailViewModel(string placeId)
        {
            _placeId = placeId;

            var settings = GoogleApiSettings.Builder.WithApiKey(Environment.GetEnvironmentVariable("GOOGLE_PLACES_API_KEY")).Build();

            _api = new GooglePlacesApiService(settings);

            TaskCompletion = NotifyTaskCompletion.Create(GetPlaceDetailsAsync);
        }

        public INotifyTaskCompletion TaskCompletion;

        private Details _details;
        public Details Details
        {
            get => _details;
            set => SetProperty(ref _details, value);
        }

        private async Task GetPlaceDetailsAsync()
        => Details = await _api.GetDetailsAsync(_placeId)
                               .ConfigureAwait(false);
    }
}