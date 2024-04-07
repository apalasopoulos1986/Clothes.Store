using Clothes.Store.Common.Models.Result;
using Clothes.Store.Db.Context;
using Clothes.Store.Db.DbEntities;
using Clothes.Store.Db.Interfaces;
using Dapper;

namespace Clothes.Store.Db.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context)=>_context=context;

        private static string GetAllProductsFromDb = @" SELECT * FROM Products ";

        public async Task<Result<IEnumerable<Product>>> GetProductsFromDb()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var products = await connection.QueryAsync<Product>(GetAllProductsFromDb);
                    return Result<IEnumerable<Product>>.ActionSuccessful(products.ToList(), Clothes.Store.Common.Models.Result.ResponseCodes.Codes.OK);
                }
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<Product>>.Exception(Clothes.Store.Common.Models.Result.ResponseCodes.Codes.InternalError, ex);
            }
        }
    }
}
