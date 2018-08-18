using System.Linq;
using GooglePlacesApi.Abstractions.Models;
using GooglePlacesApi.Abstractions.Models.GoogleApi;

namespace GooglePlacesApi.Extensions
{
    public static class QueryStringParametersExtension
    {
        public static GoogleApiQueryStringParameters CreateQueryStringParameters(this GoogleApiSettings settings)
        {
            var queryParams = new GoogleApiQueryStringParameters();
            queryParams.ApiKey = settings.ApiKey;
            queryParams.Language = !string.IsNullOrEmpty(settings.Language) ? $"{settings.Language}" : string.Empty;

            if(settings.Countries != null && settings.Countries.Any())
            {
                queryParams.Country = string.Join("|", settings.Countries.Select(x => $"country:{x}"));
            }

            switch(settings.PlaceType)
            {
                case PlaceTypes.Address:
                    queryParams.PlaceType = "address";
                    break;

                case PlaceTypes.Cities:
                    queryParams.PlaceType = "(cities)";
                    break;
                
                case PlaceTypes.Establishment:
                    queryParams.PlaceType = "establishment";
                    break;

                case PlaceTypes.GeoCode:
                    queryParams.PlaceType = "geocode";
                    break;

                case  PlaceTypes.Regions:
                    queryParams.PlaceType = "(regions)";
                    break;
            }

            return queryParams;
        }
    }
}
