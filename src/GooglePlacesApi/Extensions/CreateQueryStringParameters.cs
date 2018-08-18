using GooglePlacesApi.Abstractions.Models;

namespace GooglePlacesApi.Extensions
{
    public static class QueryStringParametersExtension
    {
        public static GoogleApiQueryStringParameters CreateQueryStringParameters(this GoogleApiSettings settings)
        {
            return new GoogleApiQueryStringParameters(settings.ApiKey,
                                                      settings.Language);

        }
    }
}
