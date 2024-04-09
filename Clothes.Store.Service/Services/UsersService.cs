using Clothes.Store.Common.Models.Result.ResponseCodes;
using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Requests;
using Clothes.Store.Db.Interfaces;
using Clothes.Store.Service.Interfaces;
using Clothes.Store.Db.Extensions;
using Clothes.Store.Db.DbEntities;
using Clothes.Store.Common.Responses;
using Clothes.Store.Common.Models;
using Newtonsoft.Json;


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

        public async Task<Result<List<UserResponse>>> GetAllUsersAsync()
        {
            try
            {
                var usersResult = await _userRepository.GetAllUsersAsyncFromDb(); 
                if (!usersResult.Success)
                {
                    return Result<List<UserResponse>>.ActionFailed(null, usersResult.Code, usersResult.Info);
                }

                var usersDb = usersResult.Data; 
                var userResponses = usersDb.Select(user => ConvertToUserResponse(user)).ToList();
                return Result<List<UserResponse>>.ActionSuccessful(userResponses, Codes.OK);
            }
            catch (Exception ex)
            {
            
                return Result<List<UserResponse>>.Exception(Codes.InternalError, ex);
            }
        }

        public async Task<Result<UserResponse>> GetUserByIdAsync(int id)
        {
            try
            {
                var userResult= await _userRepository.GetUserByIdAsyncFromDb(id);
                if (!userResult.Success)
                {
                    return Result<UserResponse>.ActionFailed(null, userResult.Code, userResult.Info);

                }
                var userDb = userResult.Data;
                var userResponse = ConvertToUserResponse(userDb);
                return Result<UserResponse>.ActionSuccessful(userResponse, Codes.OK);
            }
            catch (Exception ex)
            {

                return Result<UserResponse>.Exception(Codes.InternalError, ex);
            }
        }
        public async Task<Result<bool>> DeleteUserAsync(int userId)
        {
            try
            {
                
                var deleteResult = await _userRepository.DeleteUserAsyncFromDb(userId);

                if (!deleteResult.Success)
                {
                    return Result<bool>.ActionFailed(false, deleteResult.Code, deleteResult.Info);
                }

                return Result<bool>.ActionSuccessful(true, Codes.OK);
            }
            catch (Exception ex)
            {
                return Result<bool>.Exception(Codes.InternalError, ex);
            }
        }

        private UserResponse ConvertToUserResponse(User user)
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
    }
}
