using System.Collections.Generic;
using Newtonsoft.Json;

namespace GooglePlacesApi.Models
{
    public class Photo
    {
        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("html_attributions")]
        public List<string> HtmlAttributions { get; set; }

        [JsonProperty("photo_reference")]
        public string PhotoReference { get; set; }
    }
}
