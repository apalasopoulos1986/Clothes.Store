using Clothes.Store.Common.Models.Result;
using Clothes.Store.Db.DbEntities;


namespace Clothes.Store.Db.Interfaces
{
    public interface IPurchaseRepository
    {
        public  Task<Result<bool>> PurchaseProductAsyncDb(int userId, int productId);
        public  Task<Result<List<User>>> GetUsersByProductIdAsyncDb(int productId);

        public Task<Result<List<Product>>> GetPurchasedProductsByUserIdAsyncDb(int userId);
    }
}
