using Clothes.Store.Common.Models.Result;
using Clothes.Store.Db.DbEntities;

namespace Clothes.Store.Db.Interfaces
{
    public interface IUserRepository
    {
        public Task<Result<List<User>>> GetAllUsersAsyncFromDb();
        public Task<Result<bool>> CreateUserAsync(User user);

        public Task<Result<User>> GetUserByIdAsyncFromDb(int id);


        public Task<Result<bool>> DeleteUserAsyncFromDb(int userId);
    }
}
