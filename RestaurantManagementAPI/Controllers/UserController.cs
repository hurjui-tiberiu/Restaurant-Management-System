using Microsoft.AspNetCore.Mvc;
using RestaurantManagementAPI.Application.Interfaces;
using RestaurantManagementAPI.Application.Models;

namespace RestaurantManagementAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("users/register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var userId = await userService.Register(userDto);

            return Ok(userId);
        }

        [HttpGet, Route("users/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await userService.GetUserById(id);
            return Ok(user);
        }

        [HttpDelete, Route("users/{id}")]
        public async Task<IActionResult> DeleteUserById(Guid id)
        {
            await userService.DeleteUserById(id);

            return NoContent();
        }

        [HttpPost, Route("users/login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var userLoginResponse = await userService.Login(userLoginDto);

            return Ok(userLoginResponse);
        }
    }
}
