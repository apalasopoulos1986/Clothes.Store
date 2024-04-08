

using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Responses;

namespace Clothes.Store.Service.Interfaces
{
    public interface IUsersMigrationService
    {
        public  Task<Result<List<UserResponse>>> FetchUsersFromJsonFileAsync();
    }
}
