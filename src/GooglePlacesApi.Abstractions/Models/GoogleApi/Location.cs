using Newtonsoft.Json;

namespace GooglePlacesApi.Abstractions.Models
{
    public class Location
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}
