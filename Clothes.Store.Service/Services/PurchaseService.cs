using Clothes.Store.Common.Models.Result.ResponseCodes;
using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Responses;
using Clothes.Store.Db.Interfaces;
using Clothes.Store.Service.Interfaces;
using Clothes.Store.Service.Extensions;

namespace Clothes.Store.Service.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<Result<bool>> PurchaseProductAsync(int userId, int productId)
        {
            try
            {
                return await _purchaseRepository.PurchaseProductAsyncDb(userId, productId);
            }
            catch (Exception ex)
            {
                return Result<bool>.Exception(Codes.InternalError, ex);
            }
        }

        public async Task<Result<List<UserResponse>>> GetUsersByProductIdAsync(int productId)
        {
            try
            {
                var usersResult = await _purchaseRepository.GetUsersByProductIdAsyncDb(productId);

                if (!usersResult.Success)
                {
                    return Result<List<UserResponse>>.ActionFailed(null, usersResult.Code, usersResult.Info);
                }


                var userResponses = usersResult.Data.Select(user => JsonExtensions.ConvertToUserResponse(user)).ToList();

                return Result<List<UserResponse>>.ActionSuccessful(userResponses, Codes.OK);
            }
            catch (Exception ex)
            {
                return Result<List<UserResponse>>.Exception(Codes.InternalError, ex);
            }
        }

        public async Task<Result<List<ProductResponse>>> GetPurchasedProductsByUserIdAsync(int userId)
        {
            try
            {
                var productsResult = await _purchaseRepository.GetPurchasedProductsByUserIdAsyncDb(userId);

                if (!productsResult.Success)
                {
                    return Result<List<ProductResponse>>.ActionFailed(null, productsResult.Code, productsResult.Info);
                }


                var productResponses = productsResult.Data.Select(product => JsonExtensions.ConvertToProductResponse(product)).ToList();

                return Result<List<ProductResponse>>.ActionSuccessful(productResponses, Codes.OK);
            }
            catch (Exception ex)
            {
                return Result<List<ProductResponse>>.Exception(Codes.InternalError, ex);
            }
        }



    }
}