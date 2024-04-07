using Newtonsoft.Json;
namespace Clothes.Store.Common.Models
{
    /// <summary>
    /// Address of user
    /// </summary>
 
    public class Address
    {
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
