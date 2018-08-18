using Newtonsoft.Json;

namespace GooglePlacesApi.Abstractions.Models
{
    public class Place
    {
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }
}
