using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Requests;
using Clothes.Store.Db.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Service.Interfaces
{
    public interface IUserService
    {
        public Task<Result<bool>> CreateUserAsync(UserCreateRequest request);

        public  Task<Result<List<User>>> GetAllUsersAsync();

        public Task<Result<User>> GetUserByIdAsync(int id);
    }
}
