using Clothes.Store.Common.Responses;
using Clothes.Store.Db.DbEntities;
using Newtonsoft.Json;


namespace Clothes.Store.Db.Extensions
{
    public static class UserExtension
    {
        public static User ToUser(this UserResponse response)
        {

            var user = new User
            {
                Id = response.Id,
                FirstName = response.FirstName,
                LastName = response.LastName,
                Gender = response.Gender,
                Age = response.Age,
                Address = JsonConvert.SerializeObject(response.Address),
                PhoneNumbers = JsonConvert.SerializeObject(response.PhoneNumbers)
            };

            return user;
        }
    }
}
