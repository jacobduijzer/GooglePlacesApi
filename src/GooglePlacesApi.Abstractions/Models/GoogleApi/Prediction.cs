using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GooglePlacesApi.Abstractions.Models
{
    public class Prediction
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("place_id")]
        public string Place_id { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        public List<PredictionMatchedSubstring> matched_substrings { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("terms")]
        public List<PredictionTerm> Terms { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }
}
