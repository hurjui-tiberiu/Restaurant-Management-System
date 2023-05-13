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

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var userId = await userService.Register(userDto);

            return Ok(userId);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await userService.GetUserById(id);
            return Ok(user);
        }
        
        
    }
}
