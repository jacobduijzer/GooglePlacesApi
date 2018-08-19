using Newtonsoft.Json;

namespace GooglePlacesApi.Models
{
    public class Geometry
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
