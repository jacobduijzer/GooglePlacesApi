using System.Collections.Generic;
using Newtonsoft.Json;

namespace GooglePlacesApi.Models
{
    public class Place
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("address_components")]
        public List<AddressComponent> AddressComponents { get; set; }

        [JsonProperty("adr_address")]
        public string AdrAddress { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }

        [JsonProperty("Photos")]
        public List<Photo> Photos { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("ulr")]
        public string Url { get; set; }

        [JsonProperty("utc_offset")]
        public int UtcOffset { get; set; }

        [JsonProperty("vicinity")]
        public string Vicinity { get; set; }
    }
}
