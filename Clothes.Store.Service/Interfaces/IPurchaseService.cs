

using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Responses;

namespace Clothes.Store.Service.Interfaces
{
    public  interface IPurchaseService
    {
        public Task<Result<bool>> PurchaseProductAsync(int userId, int productId);
        public Task<Result<List<UserResponse>>> GetUsersByProductIdAsync(int productId);

        public Task<Result<List<ProductResponse>>> GetPurchasedProductsByUserIdAsync(int userId);
    }
}
