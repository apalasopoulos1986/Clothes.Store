using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Responses;
using Clothes.Store.Db.Context;
using Clothes.Store.Db.DbEntities;
using Clothes.Store.Db.Extensions;
using Clothes.Store.Db.Interfaces;
using Dapper;
using System.Data;

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


        public async Task<Result<bool>> InsertProductsAsync(IEnumerable<ProductResponse> productResponses)
        {
            var connection = _context.CreateConnection();
            IDbTransaction transaction = connection.BeginTransaction();

            try
            {
                foreach (var response in productResponses)
                {
                    var product = response.ToProduct(); 

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", product.Id, DbType.Int32);
                    parameters.Add("@Title", product.Title, DbType.String);
                    parameters.Add("@Price", product.Price, DbType.Decimal);
                    parameters.Add("@Description", product.Description, DbType.String);
                    parameters.Add("@Category", product.Category, DbType.String);
                    parameters.Add("@Image", product.Image, DbType.String);
                    parameters.Add("@Rating", product.Rating, DbType.String); 

                    await connection.ExecuteAsync("InsertProductResponseFromWebService", parameters, transaction, commandType: CommandType.StoredProcedure);
                }

                transaction.Commit();
                return Result<bool>.ActionSuccessful(true, Clothes.Store.Common.Models.Result.ResponseCodes.Codes.OK);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return Result<bool>.Exception(Clothes.Store.Common.Models.Result.ResponseCodes.Codes.InternalError, ex);
            }
        }
    }
}
