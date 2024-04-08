using Clothes.Store.Common.Models.Result;
using Clothes.Store.Service.Interfaces;
using Clothes.Store.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clothes.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersMigrationController : ControllerBase
    {

        private readonly IUsersMigrationService _usersMigrationService;

        public UsersMigrationController(IUsersMigrationService usersMigrationService)
        {
            _usersMigrationService=usersMigrationService;
        }


        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> FetchAllUsersFromFile()
        {
            var result = await _usersMigrationService.FetchUsersFromJsonFileAsync();
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
