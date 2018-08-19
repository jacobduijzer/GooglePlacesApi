using Newtonsoft.Json;

namespace GooglePlacesApi.Models
{
    public class PredictionMatchedSubstring
    {
        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
}
