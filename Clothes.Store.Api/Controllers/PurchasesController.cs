using Clothes.Store.Common.Models.Result.ResponseCodes;
using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Requests;
using Clothes.Store.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clothes.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchasesController(IPurchaseService purchaseService) => _purchaseService = purchaseService;

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> PurchaseProduct([FromBody] PurchaseRequest request)
        {
            var purchaseResult = await _purchaseService.PurchaseProductAsync(request.UserId, request.ProductId);

            if (purchaseResult.Success)
            {
                return Ok(purchaseResult.Data);
            }
            else
            {
                switch (purchaseResult.Code)
                {
                    case Codes.BadRequest:
                        return BadRequest(purchaseResult.Info);
                    case Codes.InternalError:
                        return StatusCode(500, purchaseResult.Info);
                    default:
                        return StatusCode(purchaseResult.Code, purchaseResult.Info ?? new Info { Message = "An unexpected error occurred." });
                }
            }
        }
       
        [HttpGet("UsersByProductId/{productId}")]
        public async Task<IActionResult> GetUsersByProductId(int productId)
        {
            var result = await _purchaseService.GetUsersByProductIdAsync(productId);

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
       
        [HttpGet("PurchasedProductsByUserId/{userId}")]
        public async Task<IActionResult> GetPurchasedProductsByUserId(int userId)
        {
            var result = await _purchaseService.GetPurchasedProductsByUserIdAsync(userId);

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
