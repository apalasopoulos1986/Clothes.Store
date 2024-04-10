using Clothes.Store.Service.Interfaces;
using Clothes.Store.Common.Models.Settings;
using Microsoft.Extensions.Options;
using Clothes.Store.Common.Models.Result.ResponseCodes;
using Clothes.Store.Common.Models.Result;
using Clothes.Store.Service.Extensions;
using Clothes.Store.Common.Responses;
using Clothes.Store.Db.Interfaces;


namespace Clothes.Store.Service.Services
{
    public class ProductsMigrationService : IProductsMigrationService
    {
        private readonly StoreSettings _settings;
        private readonly HttpClient _client;
        private readonly IProductRepository _productRepo;
        public ProductsMigrationService(
             IHttpClientFactory httpClientFactory,
             IOptions<StoreSettings> _options,
             IProductRepository productRepo)
        {
            _client = httpClientFactory.CreateClient($"{nameof(ProductsMigrationService)}");
            _settings = _options.Value;
            _productRepo = productRepo;
        }
        public async Task<Result<List<ProductResponse>>> FetchProductsFromWebServiceAsync()
        {
            try
            {
                var response = await _client.GetAsync(_settings.BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    var products = JsonExtensions.TransformProducts(jsonString);

                    return Result<List<ProductResponse>>.ActionSuccessful(products, Codes.OK);
                }
                else
                {
                    return Result<List<ProductResponse>>.ActionFailed(null, Codes.BadRequest, new Info
                    {
                        Code = response.StatusCode.ToString(),
                        Message = "Failed to fetch products from the API."
                    });
                }
            }
            catch (Exception ex)
            {
                return Result<List<ProductResponse>>.Exception(Codes.InternalError, ex);
            }
        }


        public async Task<Result<bool>> MigrateProductsAsync()
        {
            try
            {

                var fetchResult = await FetchProductsFromWebServiceAsync();

                if (!fetchResult.Success)
                {
                    return Result<bool>.ActionFailed(false, fetchResult.Code, fetchResult.Info);
                }


                var insertResult = await _productRepo.InsertProductsAsync(fetchResult.Data);

                if (!insertResult.Success)
                {
                    return insertResult;
                }

                return Result<bool>.ActionSuccessful(true, insertResult.Code);
            }
            catch (Exception ex)
            {
                return Result<bool>.Exception(Common.Models.Result.ResponseCodes.Codes.InternalError, ex);
            }
        }
        public async Task<Result<int>> UpdateProductsFromWebServiceAsync()
        {
            try
            {
                var fetchResult = await FetchProductsFromWebServiceAsync();

                if (!fetchResult.Success)
                {
                    return Result<int>.ActionFailed(0, fetchResult.Code, fetchResult.Info);
                }

                var updateResult = await _productRepo.UpdateProductAsync(fetchResult.Data);


                return Result<int>.ActionSuccessful(updateResult.Data, updateResult.Code);
            }
            catch (Exception ex)
            {
                return Result<int>.Exception(Common.Models.Result.ResponseCodes.Codes.InternalError, ex);
            }
        }
    }
}
