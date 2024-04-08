using Newtonsoft.Json;

namespace Clothes.Store.Common.Models
{
    /// <summary>
    /// Number of User
    /// </summary>
 
    public class PhoneNumber
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }
}
