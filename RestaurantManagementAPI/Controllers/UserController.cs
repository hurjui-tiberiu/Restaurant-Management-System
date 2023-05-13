using Microsoft.AspNetCore.Mvc;
using RestaurantManagementAPI.Application.Interfaces;
using RestaurantManagementAPI.Application.Models;

namespace RestaurantManagementAPI.Controllers
{
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IUserService userService;

        public RestaurantController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var userId = await userService.Register(userDto);

            return Ok(userId);
        }
    }
}
