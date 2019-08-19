using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace GooglePlacesApi.Models
{
    public class Place
    {
        // Basic fields

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

        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }

        [JsonProperty("plus_code")]
        public PlusCode PlusCode { get; set; }
        
        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("utc_offset")]
        public int UtcOffset { get; set; }

        [JsonProperty("vicinity")]
        public string Vicinity { get; set; }
        
        [JsonProperty("permanently_closed")]
        public bool PermanentlyClosed { get; set; }

        //Contact details (billed extra if requested)

        [JsonProperty("international_phone_number")]
        public string InternationalPhoneNumber { get; set; }

        [JsonProperty("formatted_phone_number")]
        public string FormattedPhoneNumber { get; set; }

        [JsonProperty("opening_hours")]
        public OpeningHours OpeningHours { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        //Atmosphere details (billed extra if requested)

        [JsonProperty("price_level")]
        public int PriceLevel { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("reviews")]
        public List<Review> Reviews { get; set; }

        [JsonProperty("user_ratings_total")]
        public string UserRatingsTotal { get; set; }
    }
}
