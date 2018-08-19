using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GooglePlacesApi.Models
{
    public class Predictions
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("predictions")]
        public List<Prediction> Items { get; set; }
    }
}
