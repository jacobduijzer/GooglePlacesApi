using Refit;
using System;

namespace GooglePlacesApi.Models
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

        [AliasAs("sessiontoken")]
        public string SessionToken { get; set; }

        public int Offset { get; set; }

        [AliasAs("origin")]
        public string Origin { get; set; }

        [AliasAs("location")]
        public string Location { get; set; }

        public int Radius { get; set; }

        public bool StrictBounds { get; set; }
    }
}
