using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Models.Result.ResponseCodes;
using Clothes.Store.Db.Context;
using Clothes.Store.Db.DbEntities;
using Clothes.Store.Db.Interfaces;
using Dapper;


namespace Clothes.Store.Db.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly DapperContext _context;

        public UserRepository(DapperContext context) => _context = context;

        private static string SelectAllUsersQuery = " SELECT * FROM Users ";

        private static string CreateUserQuery = " INSERT INTO Users (FirstName, LastName, Gender, Age, Address, PhoneNumbers) VALUES (@FirstName, @LastName, @Gender, @Age, @Address, @PhoneNumbers) ";

        private static string GetUserByIdQuery = " SELECT * FROM Users WHERE Id = @Id ";

        private static string CheckUserExistsQuery = @"
                SELECT COUNT(*) 
                FROM Users 
                WHERE FirstName = @FirstName AND LastName = @LastName AND Age = @Age AND Gender = @Gender";

        public async Task<Result<List<User>>> GetAllUsersAsyncFromDb()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var users = await connection.QueryAsync<User>(SelectAllUsersQuery);

                    return Result<List<User>>.ActionSuccessful(users.ToList(), Codes.OK);

                }
            }
            catch (Exception ex)
            {

                return Result<List<User>>.Exception(Codes.InternalError, ex);
            }
        }


        public async Task<Result<bool>> CreateUserAsync(User user)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var userExists =
                        await
                        connection.QuerySingleAsync<int>(CheckUserExistsQuery,
                        new { user.FirstName, user.LastName, user.Age, user.Gender });

                    if (userExists > 0)
                    {
                        return Result<bool>.ActionFailed
                            (false, Clothes.Store.Common.Models.Result.ResponseCodes.Codes.Conflict,
                            new Info { Message = "A user with the same first name, last name, age, and gender already exists." });

                    }
                    await connection.ExecuteAsync(CreateUserQuery, user);

                    return Result<bool>.ActionSuccessful(true, Codes.OK);
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Exception(Codes.InternalError, ex);
            }
        }

        public async Task<Result<User>> GetUserByIdAsyncFromDb(int id)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var user = await connection.QuerySingleOrDefaultAsync<User>(GetUserByIdQuery, new { Id = id });
                    if (user != null)
                    {
                        return Result<User>.ActionSuccessful(user, Clothes.Store.Common.Models.Result.ResponseCodes.Codes.OK);
                    }
                    else
                    {
                        return Result<User>.ActionFailed(null, Clothes.Store.Common.Models.Result.ResponseCodes.Codes.NotFound, new Info { Message = "User not found." });
                    }
                }
            }
            catch (Exception ex)
            {
                return Result<User>.Exception(Clothes.Store.Common.Models.Result.ResponseCodes.Codes.InternalError, ex);
            }
        }

    }
}
