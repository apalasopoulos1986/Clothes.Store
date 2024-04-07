using System.Text.Json.Serialization;

namespace Clothes.Store.Common.Models.Result
{
    public class Info
    {
        public string? Code { get; set; }
        public string? Message { get; set; }

        [JsonIgnore]
        public Exception? Exception { get; set; }
    }
}
