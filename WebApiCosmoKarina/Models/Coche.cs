using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebApiCosmoKarina.Models
{
    public class Coches
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "make")]
        public string Make { get; set; }
        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }
    }
}
