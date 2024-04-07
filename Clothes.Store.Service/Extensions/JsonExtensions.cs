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
       
        public static Product ToProduct(this ProductResponse response)
        {
           
            var product = new Product
            {
                Id = response.Id,
                Title = response.Title,
                Price = response.Price,
                Description = response.Description,
                Category = response.Category,
                Image = response.Image,
                Rating = JsonConvert.SerializeObject(response.Rating)
            };

            return product;
        }
    }
}
