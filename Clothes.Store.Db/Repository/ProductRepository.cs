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
        public ProductRepository(DapperContext context) => _context = context;

        private static string GetAllProductsFromDbQuery = @" SELECT * FROM Products ";
        private static string InsertProductResponseFromWebServiceSp = "InsertProductResponseFromWebService";

        public async Task<Result<List<Product>>> GetProductsFromDb()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var products = await connection.QueryAsync<Product>(GetAllProductsFromDbQuery);
                    return Result<List<Product>>.ActionSuccessful(products.ToList(), Clothes.Store.Common.Models.Result.ResponseCodes.Codes.OK);
                }
            }
            catch (Exception ex)
            {
                return Result<List<Product>>.Exception(Clothes.Store.Common.Models.Result.ResponseCodes.Codes.InternalError, ex);
            }
        }


        public async Task<Result<bool>> InsertProductsAsync(List<ProductResponse> productResponses)
        {
            IDbConnection connection = null;

            try
            {
                using (connection = _context.CreateConnection())

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

                        await connection.ExecuteAsync(InsertProductResponseFromWebServiceSp, parameters, commandType: CommandType.StoredProcedure);
                    }

                    return Result<bool>.ActionSuccessful(true, Clothes.Store.Common.Models.Result.ResponseCodes.Codes.OK);
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Exception(Clothes.Store.Common.Models.Result.ResponseCodes.Codes.InternalError, ex);
            }
            finally
            {
                connection?.Dispose();
            }
        }
    }
}
