using Clothes.Store.Common.Models.Result;
using Clothes.Store.Db.Context;
using Clothes.Store.Db.DbEntities;
using Clothes.Store.Db.Interfaces;
using Dapper;


namespace Clothes.Store.Db.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DapperContext _context;
        public PurchaseRepository(DapperContext context) => _context = context;


        private static string CheckUserExistsQuery = @" SELECT COUNT(1) FROM Users WHERE Id = @UserId; ";

        private static string CheckProductExistsQuery = @" SELECT COUNT(1) FROM Products WHERE Id = @ProductId; ";

        private static string PurchaseProductQuery = @" 
                                INSERT INTO Purchases
                                (UserId, ProductId, PurchaseDate, IsUserActive) 
                                VALUES (@UserId, @ProductId, @PurchaseDate, @IsUserActive); ";


        private static string GetUsersByProductIdQuery = @"
                                SELECT u.* FROM Users u
                                INNER JOIN Purchases p ON u.Id = p.UserId
                                WHERE p.ProductId = @ProductId;";

        private static string GetPurchasedProductsByUserId = @"
                                SELECT p.* FROM Products p
                                INNER JOIN Purchases pur ON p.Id = pur.ProductId
                                WHERE pur.UserId = @UserId;";

        public async Task<Result<bool>> PurchaseProductAsync(int userId, int productId)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var userExists = await connection.ExecuteScalarAsync<bool>(CheckUserExistsQuery, new { UserId = userId });

                    if (!userExists)
                    {
                        return Result<bool>.ActionFailed(userExists,
                             Clothes.Store.Common.Models.Result.ResponseCodes.Codes.NotFound,
                             new Info { Message = "User does not exist." });
                    }

                    var productExists = await connection.ExecuteScalarAsync<bool>(CheckProductExistsQuery, new { ProductId = productId });

                    if (!productExists)
                    {
                        return Result<bool>.ActionFailed(productExists,
                            Clothes.Store.Common.Models.Result.ResponseCodes.Codes.NotFound,
                            new Info { Message = "Product does not exist." });

                    }


                    var purchase = new Purchase
                    {
                        UserId = userId,
                        ProductId = productId,
                        PurchaseDate = DateTime.UtcNow,
                        IsUserActive = true
                    };

                    var result = await
                                 connection.ExecuteAsync(PurchaseProductQuery, purchase);

                    return Result<bool>.ActionSuccessful(result > 0, Clothes.Store.Common.Models.Result.ResponseCodes.Codes.OK);
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Exception(Clothes.Store.Common.Models.Result.ResponseCodes.Codes.InternalError, ex);
            }
        }

        public async Task<Result<List<User>>> GetUsersByProductIdAsync(int productId)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var users = await
                                connection.QueryAsync<User>(GetUsersByProductIdQuery, new { ProductId = productId });

                    return Result<List<User>>.ActionSuccessful(users.ToList(), Clothes.Store.Common.Models.Result.ResponseCodes.Codes.OK);
                }
            }
            catch (Exception ex)
            {
                return Result<List<User>>.Exception(Clothes.Store.Common.Models.Result.ResponseCodes.Codes.InternalError, ex);
            }
        }

        public async Task<Result<List<Product>>> GetPurchasedProductsByUserIdAsync(int userId)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var products = await
                                  connection.QueryAsync<Product>(GetPurchasedProductsByUserId, new { UserId = userId });

                    return Result<List<Product>>.ActionSuccessful(products.ToList(),
                        Clothes.Store.Common.Models.Result.ResponseCodes.Codes.OK);
                }
            }
            catch (Exception ex)
            {
                return Result<List<Product>>.Exception(Clothes.Store.Common.Models.Result.ResponseCodes.Codes.InternalError, ex);
            }
        }
    }
}
