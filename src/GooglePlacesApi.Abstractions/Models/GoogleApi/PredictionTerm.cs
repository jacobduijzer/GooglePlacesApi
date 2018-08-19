using Newtonsoft.Json;

namespace GooglePlacesApi.Models
{
    public class PredictionTerm
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
