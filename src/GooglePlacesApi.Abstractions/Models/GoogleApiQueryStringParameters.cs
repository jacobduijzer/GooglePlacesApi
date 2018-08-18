using Refit;

namespace GooglePlacesApi.Abstractions.Models
{
    public class GoogleApiQueryStringParameters
    {
        [AliasAs("key")]
        public string ApiKey { get; set; }

        [AliasAs("language")]
        public string Language { get; set; }

        [AliasAs("components")]
        public string Country { get; set; }

        [AliasAs("types")]
        public string PlaceType { get; set; }
    }
}
