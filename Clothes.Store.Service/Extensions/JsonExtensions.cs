using Clothes.Store.Common.Responses;
using Clothes.Store.Db.DbEntities;
using Newtonsoft.Json;


namespace Clothes.Store.Service.Extensions
{
    public static class JsonExtensions
    {
        public static List<ProductResponse> TransformProducts(string json)
        {

            var products = JsonConvert.DeserializeObject<List<ProductResponse>>(json, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });

            return products;

        }
       
       
    }
}
