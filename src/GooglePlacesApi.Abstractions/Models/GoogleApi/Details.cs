using Newtonsoft.Json;

namespace GooglePlacesApi.Abstractions.Models
{
    public class Details
    {
        [JsonProperty("Result")]
        public Place Place { get; set; }
    }
}
