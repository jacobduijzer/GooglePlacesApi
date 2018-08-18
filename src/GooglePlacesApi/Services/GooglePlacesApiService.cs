using System.Net.Http;
using System.Threading.Tasks;
using GooglePlacesApi.Abstractions.Interfaces;
using GooglePlacesApi.Abstractions.Models;
using GooglePlacesApi.Extensions;
using GooglePlacesApi.Handlers;
using Refit;

namespace GooglePlacesApi
{
    public class GooglePlacesApiService : IGooglePlacesApiService
    {
        private readonly IGooglePlacesApi _api;

        private readonly GoogleApiSettings _settings;

        public GooglePlacesApiService(GoogleApiSettings settings) 
        {
            _settings = settings;

            var refitSettings = new RefitSettings();

            if (_settings.Logger != null)
                refitSettings.HttpMessageHandlerFactory = () => new LoggingHandler(new HttpClientHandler(), _settings.Logger);
            
            _api = RestService.For<IGooglePlacesApi>(Constants.BASE_API_URL, refitSettings);
        }
        public async Task<Predictions> GetPredictionsAsync(string searchText)
        => await _api.GetAutocompleteAsync(searchText, _settings.CreateQueryStringParameters())
                                 .ConfigureAwait(false);

        public Task<Predictions> GetPredictionsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
