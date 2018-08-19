using Newtonsoft.Json;

namespace GooglePlacesApi.Models
{
    public class Place
    {
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }
}
