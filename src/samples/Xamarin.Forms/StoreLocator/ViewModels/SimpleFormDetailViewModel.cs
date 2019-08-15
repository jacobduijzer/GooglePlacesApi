using System;
using System.IO;
using System.Threading.Tasks;
using GooglePlacesApi;
using GooglePlacesApi.Models;
using MvvmHelpers;
using Nito.AsyncEx;
using Xamarin.Forms;

namespace StoreLocator.ViewModels
{
    public class SimpleFormDetailViewModel : BaseViewModel
    {
        private readonly string _placeId;

        private readonly GooglePlacesApiService _api;

        public SimpleFormDetailViewModel(string placeId, string sessionToken)
        {
            _placeId = placeId;

            var settings = GoogleApiSettings.Builder.WithApiKey(Environment.GetEnvironmentVariable("GOOGLE_PLACES_API_KEY")).WithSessionToken(sessionToken).Build();

            _api = new GooglePlacesApiService(settings);

            Details = Task.Run(async () => await GetPlaceDetailsAsync()).Result;
            Task.Run(() => GetPhotoAsync(Details.Place.Photos[0].PhotoReference));
        }

        private Details _details;
        public Details Details
        {
            get => _details;
            set => SetProperty(ref _details, value);
        }

        private ImageSource _placePhoto;
        public ImageSource PlacePhoto
        {
            get => _placePhoto;
            set => SetProperty(ref _placePhoto, value);
        }

        private async Task<Details> GetPlaceDetailsAsync()
        {
            return await _api.GetDetailsAsync(_placeId, _api.GetSessionToken(), DetailLevel.Basic)
                               .ConfigureAwait(false);
        }

        private async Task GetPhotoAsync(string photoReference)
        {
            Stream photoStream = await _api.GetPhotoAsync(photoReference)
                               .ConfigureAwait(false);
            PlacePhoto = ImageSource.FromStream(() => photoStream);
        }
    }
}