using Newtonsoft.Json;

namespace GooglePlacesApi.Abstractions.Models
{
    public class Geometry
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
