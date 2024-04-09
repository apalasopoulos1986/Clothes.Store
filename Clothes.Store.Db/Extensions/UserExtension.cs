using Clothes.Store.Common.Requests;
using Clothes.Store.Db.DbEntities;
using Newtonsoft.Json;


namespace Clothes.Store.Db.Extensions
{
    public static class UserExtension
    {
        public static User ToUser(this UserCreateRequest request)
        {

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                Age = request.Age,
                Address = JsonConvert.SerializeObject(request.Address),
                PhoneNumbers = JsonConvert.SerializeObject(request.PhoneNumbers)
            };

            return user;
        }
    }
}
