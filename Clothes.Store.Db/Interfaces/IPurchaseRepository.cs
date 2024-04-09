using Clothes.Store.Common.Models.Result;
using Clothes.Store.Db.DbEntities;


namespace Clothes.Store.Db.Interfaces
{
    public interface IPurchaseRepository
    {
        public  Task<Result<bool>> PurchaseProductAsync(int userId, int productId);
        public  Task<Result<List<User>>> GetUsersByProductIdAsync(int productId);

        public Task<Result<List<Product>>> GetPurchasedProductsByUserIdAsync(int userId);
    }
}
