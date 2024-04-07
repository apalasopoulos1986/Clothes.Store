using Newtonsoft.Json;
namespace Clothes.Store.Common.Models
{
    /// <summary>
    /// Clothes Rating
    /// </summary>
    public class Rating
    {

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
