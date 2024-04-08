using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Models.Result.ResponseCodes;
using Clothes.Store.Db.Interfaces;
using Clothes.Store.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clothes.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsMigrationController : ControllerBase
    {
        private readonly IProductsMigrationService _productsMigrationService;

        private readonly IProductRepository _productRepo;


        public ProductsMigrationController
        (
            IProductsMigrationService productsMigrationService,
            IProductRepository productRepo
        )
        {
            _productsMigrationService = productsMigrationService;
            _productRepo= productRepo;
        }


        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> FetchAllProductsFromWebService()
        {
            var result = await _productsMigrationService.FetchProductsFromWebServiceAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {

                switch (result.Code)
                {
                    case Common.Models.Result.ResponseCodes.Codes.BadRequest:
                        return BadRequest(result.Info);

                    case Common.Models.Result.ResponseCodes.Codes.InternalError:

                        return StatusCode(500, result.Info);

                    default:

                        return StatusCode(result.Code, result.Info ?? new Info { Message = "An unexpected error occurred." });
                }
            }
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetProductsFromDb()
        {
            var result = await _productRepo.GetProductsFromDb();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else if (result.HasException)
            {
                
                return StatusCode(Codes.InternalError, result.Info?.Message);
            }
            else
            {              
                return StatusCode(result.Code, result.Info?.Message);
            }
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> MigrateProductsFromWebService()
        {
            var result = await _productsMigrationService.MigrateProductsAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else if (result.HasException)
            {

                return StatusCode(Codes.InternalError, result.Info?.Message);
            }
            else
            {
                return StatusCode(result.Code, result.Info?.Message);
            }
        }

    }
}
