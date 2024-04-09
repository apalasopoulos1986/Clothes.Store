using Clothes.Store.Common.Models;
using Newtonsoft.Json;

namespace Clothes.Store.Common.Requests
{
    public class UserCreateRequest
    {
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
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}

