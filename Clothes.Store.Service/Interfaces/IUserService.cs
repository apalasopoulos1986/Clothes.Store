using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Requests;
using Clothes.Store.Common.Responses;

namespace Clothes.Store.Service.Interfaces
{
    public interface IUserService
    {
        public Task<Result<bool>> CreateUserAsync(UserCreateRequest request);

        public Task<Result<List<UserResponse>>> GetAllUsersAsync();

        public Task<Result<UserResponse>> GetUserByIdAsync(int id);
    }
}
