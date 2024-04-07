
using Clothes.Store.Common.Models;
using Newtonsoft.Json;

namespace Clothes.Store.Common.Responses
{
    public class UserResponse
    {

        [JsonProperty("userId")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phoneNumbers")]
        public PhoneNumbers PhoneNumbers { get; set; }
    }
}
