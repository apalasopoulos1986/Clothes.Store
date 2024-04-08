using Clothes.Store.Common.Models;
using Newtonsoft.Json;


namespace Clothes.Store.Common.Responses
{
    /// <summary>
    /// Product response from API Call
    /// </summary>
    public class ProductResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }
       
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
     
        [JsonProperty("rating")]
        public Rating Rating { get; set; }
    }
}
