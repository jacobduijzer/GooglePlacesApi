using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace GooglePlacesApi.Models
{
    public class Period
    {
        
        [JsonProperty("open")]
        public PeriodDetail Open { get; set; }

        [JsonProperty("close")]
        public PeriodDetail Close { get; set; }
    }
}
