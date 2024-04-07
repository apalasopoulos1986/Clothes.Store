using Newtonsoft.Json;

namespace Clothes.Store.Common.Models
{
    /// <summary>
    /// Numbers of User
    /// </summary>
 
    public class PhoneNumbers
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }
}
