using Clothes.Store.Common.Models;
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
        public static UserResponse ConvertToUserResponse(this User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Age = user.Age,
                Address = JsonConvert.DeserializeObject<Address>(user.Address),
                PhoneNumbers = JsonConvert.DeserializeObject<List<PhoneNumber>>(user.PhoneNumbers)
            };
        }


        public static ProductResponse ConvertToProductResponse(this Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category,
                Image = product.Image,
                Rating = JsonConvert.DeserializeObject<Rating> (product.Rating)
            };
        }


    }
}
