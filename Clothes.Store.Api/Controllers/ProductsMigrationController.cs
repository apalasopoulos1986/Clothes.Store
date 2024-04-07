
using Clothes.Store.Common.Models.Result;
using Clothes.Store.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clothes.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsMigrationController : ControllerBase
    {
        private readonly IProductsMigrationService _productsMigrationService;

        public ProductsMigrationController
        (
            IProductsMigrationService productsMigrationService
        )
        {
            _productsMigrationService = productsMigrationService;
        }


        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> FetchAllProducts()
        {
            var result = await _productsMigrationService.FetchProductsAsync();
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
    }
}
