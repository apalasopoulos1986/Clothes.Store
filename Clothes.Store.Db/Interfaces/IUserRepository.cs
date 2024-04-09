using Clothes.Store.Common.Models.Result;
using Clothes.Store.Db.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Db.Interfaces
{
    public interface IUserRepository
    {
        public Task<Result<List<User>>> GetAllUsersAsync();
        public Task<Result<bool>> CreateUserAsync(User user);

        public Task<Result<User>> GetUserByIdAsync(int id);
    }
}
