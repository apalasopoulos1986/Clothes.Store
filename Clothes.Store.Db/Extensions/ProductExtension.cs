using Clothes.Store.Common.Responses;
using Clothes.Store.Db.DbEntities;
using Newtonsoft.Json;

namespace Clothes.Store.Db.Extensions
{
    public static class ProductExtension
    {
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
