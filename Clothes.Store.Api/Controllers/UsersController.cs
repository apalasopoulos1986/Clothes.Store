﻿using Clothes.Store.Common.Models.Result.ResponseCodes;
using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Requests;
using Clothes.Store.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clothes.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("[action]")]
        [HttpPost]
      
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest request)
        {
          

            var createResult = await _userService.CreateUserAsync(request);

            if (createResult.Success)
            {
                return Ok(createResult);
            }
            else
            {
                return StatusCode(createResult.Code, createResult);
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(result.Code, result);
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(result.Code, result);
            }
        }


        [Route("[action]")]
        [HttpDelete]

        public async Task<IActionResult> DeleteUser([FromBody] int id)
        {
           

            var deleteResult = await _userService.DeleteUserAsync(id);

            if (deleteResult.Success)
            {
                return Ok(deleteResult);
            }
            else
            {
                return StatusCode(deleteResult.Code, deleteResult);
            }
        }
    }
}
