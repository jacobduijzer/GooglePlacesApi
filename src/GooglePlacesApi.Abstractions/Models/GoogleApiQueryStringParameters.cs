using Refit;

namespace GooglePlacesApi.Abstractions.Models
{
    public class GoogleApiQueryStringParameters
    {
        [AliasAs("key")]
        public string ApiKey { get; private set; }

        [AliasAs("language")]
        public string Language { get; private set; }

        public GoogleApiQueryStringParameters(string apiKey, string language)
        {
            ApiKey = apiKey;
            Language = language;
        }
    }
}
