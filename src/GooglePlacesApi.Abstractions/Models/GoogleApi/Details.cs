using Newtonsoft.Json;

namespace GooglePlacesApi.Models
{
    public class Details
    {
        [JsonProperty("Result")]
        public Place Place { get; set; }
    }
}
