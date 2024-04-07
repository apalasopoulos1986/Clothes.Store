using Clothes.Store.Service.Interfaces;
using Clothes.Store.Common.Models.Settings;
using Microsoft.Extensions.Options;
using Clothes.Store.Common.Models.Result.ResponseCodes;
using Clothes.Store.Common.Models.Result;
using Clothes.Store.Service.Extensions;
using Clothes.Store.Common.Responses;



namespace Clothes.Store.Service.Services
{
    public class ProductsMigrationService : IProductsMigrationService
    {
        private readonly StoreSettings _settings;
        private readonly HttpClient _client;
        public ProductsMigrationService(
             IHttpClientFactory httpClientFactory,
             IOptions<StoreSettings> _options)
        {
            _client = httpClientFactory.CreateClient($"{nameof(ProductsMigrationService)}");
            _settings = _options.Value;
        }
        public async Task<Result<List<ProductResponse>>> FetchProductsAsync()
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

    }
}
