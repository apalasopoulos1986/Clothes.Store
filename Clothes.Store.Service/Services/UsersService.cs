using Clothes.Store.Common.Models.Result.ResponseCodes;
using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Requests;
using Clothes.Store.Db.Interfaces;
using Clothes.Store.Service.Interfaces;
using Clothes.Store.Db.Extensions;
using Clothes.Store.Db.DbEntities;


namespace Clothes.Store.Service.Services
{
    public class UsersService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<Result<bool>> CreateUserAsync(UserCreateRequest request)
        {
            try
            {

                var user = request.ToUser();

                return await _userRepository.CreateUserAsync(user);
            }
            catch (Exception ex)
            {
               
                return Result<bool>.Exception(Codes.InternalError, ex);
            }
        }

        public async Task<Result<List<User>>> GetAllUsersAsync()
        {
            try
            {
                return await _userRepository.GetAllUsersAsync();
            }
            catch (Exception ex)
            {

                return Result<List<User>>.Exception(Codes.InternalError, ex);
            }
        }

        public async Task<Result<User>> GetUserByIdAsync(int id)
        {
            try
            {
                return await _userRepository.GetUserByIdAsync(id);
            }
            catch (Exception ex)
            {

                return Result<User>.Exception(Codes.InternalError, ex);
            }
        }
    }
}
