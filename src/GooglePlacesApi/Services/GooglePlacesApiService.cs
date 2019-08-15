using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GooglePlacesApi.Extensions;
using GooglePlacesApi.Handlers;
using GooglePlacesApi.Interfaces;
using GooglePlacesApi.Models;
using Newtonsoft.Json;
using Refit;

namespace GooglePlacesApi
{
    public class GooglePlacesApiService : IGooglePlacesApiService
    {
        private readonly IGooglePlacesApi _api;

        private readonly GoogleApiSettings _settings;

        public GooglePlacesApiService(GoogleApiSettings settings) 
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrEmpty(settings.ApiKey))
                throw new InvalidOperationException("ApiKey must be set");

            if (string.IsNullOrEmpty(settings.SessionToken))
                settings.SessionToken = Guid.NewGuid().ToString();

            _settings = settings;

            JsonConvert.DefaultSettings =
            () => new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore };

            var refitSettings = new RefitSettings();

            if (_settings.Logger != null)
                refitSettings.HttpMessageHandlerFactory = () => new LoggingHandler(new HttpClientHandler(), _settings.Logger);

            _api = RestService.For<IGooglePlacesApi>(Constants.BASE_API_URL, refitSettings);           
        }
        
        public async Task<Predictions> GetPredictionsAsync(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                throw new ArgumentNullException(nameof(searchText));

            return await _api.GetAutocompleteAsync(searchText, _settings.CreateQueryStringParameters())
                                 .ConfigureAwait(false);
        }

        public async Task<Details> GetDetailsAsync(string placeId, string sessionToken, DetailLevel detailLevel = DetailLevel.Basic)
        {
            if (string.IsNullOrWhiteSpace(placeId))
                throw new ArgumentNullException(nameof(placeId));

            string fields = null;

            switch (detailLevel)
            {
                case DetailLevel.Basic:
                    fields = "id,place_id,name,geometry,formatted_address,reference,icon,address_components,adr_address,types,photos,plus_code,scope,url,utc_offset,vicinity,permanently_closed";
                    break;

                case DetailLevel.Contact:
                    fields = "id,place_id,name,geometry,formatted_address,reference,icon,address_components,adr_address,types,photos,plus_code,scope,url,utc_offset,vicinity,permanently_closed,formatted_phone_number,international_phone_number,opening_hours,website";
                    break;

                case DetailLevel.Atmosphere:
                    fields = "id,place_id,name,geometry,formatted_address,reference,icon,address_components,adr_address,types,photos,plus_code,scope,url,utc_offset,vicinity,permanently_closed,price_level,rating,review,user_ratings_total";
                    break;

                case DetailLevel.Full:
                    fields = "id,place_id,name,geometry,formatted_address,reference,icon,address_components,adr_address,types,photos,plus_code,scope,url,utc_offset,vicinity,permanently_closed,formatted_phone_number,international_phone_number,opening_hours,website,price_level,rating,review,user_ratings_total";
                    break;
            }

            var result = await _api.GetDetailsAsync(_settings.ApiKey, placeId, sessionToken, fields)
                             .ConfigureAwait(false);
            // as session has been fully used now, reset session: does not have effect when the details are retreived in different instance of the service: therefore you can also call for a reset in your forms project
            ResetSessionToken();
            return result;
        }

        public async Task<Stream> GetPhotoAsync(string photoReference)
        {
            if (string.IsNullOrWhiteSpace(photoReference))
                throw new ArgumentNullException(nameof(photoReference));

            Stream result = await _api.GetPhotoAsync(_settings.ApiKey, photoReference)
                             .ConfigureAwait(false);

            return result;
        }
        public string GetSessionToken()
        {
            return _settings.SessionToken;
        }
        public void ResetSessionToken()
        {
            _settings.SessionToken = Guid.NewGuid().ToString();
        }
    }
}
