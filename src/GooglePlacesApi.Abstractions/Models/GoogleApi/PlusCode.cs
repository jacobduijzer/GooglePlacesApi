using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace GooglePlacesApi.Models
{
    public class PlusCode
    {
        [JsonProperty("open")]
        public string CompoundCode { get; set; }

        [JsonProperty("close")]
        public string GlobalCode { get; set; }
    }
}
