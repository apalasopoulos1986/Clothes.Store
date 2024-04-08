
using Clothes.Store.Common.Models.Result.ResponseCodes;
using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Responses;
using Clothes.Store.Common.Settings;
using Clothes.Store.Service.Extensions;
using Clothes.Store.Service.Interfaces;
using Microsoft.Extensions.Options;


namespace Clothes.Store.Service.Services
{
    public class UsersMigrationService : IUsersMigrationService
    {
        private readonly PathSettings _pathSettings;

        public UsersMigrationService(IOptions<PathSettings> _options)
        {
            _pathSettings = _options.Value;
        }


        public async Task<Result<List<UserResponse>>> FetchUsersFromJsonFileAsync()
        {
            try
            {

                string json = File.ReadAllText(_pathSettings.UsersFilePath);

                if (json is not null)
                {
                    var users = JsonExtensions.TransformUsers(json);

                    return Result<List<UserResponse>>.ActionSuccessful(users, Codes.OK);
                }
                else
                {
                    return Result<List<UserResponse>>.ActionFailed(null, Codes.BadRequest, new Info
                    {
                        Message = "Failed to fetch Users from the File."
                    });
                }
            }
            catch (Exception ex)
            {
                return Result<List<UserResponse>>.Exception(Codes.InternalError, ex);
            }
        }

    }
}
