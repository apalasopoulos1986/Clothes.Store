using Clothes.Store.Common.Responses;
using Newtonsoft.Json;

namespace Clothes.Store.Common.Models
{
    public class UserRootObject
    {
        [JsonProperty("users")]
        public List<UserResponse> Users { get; set; }
    }
}
