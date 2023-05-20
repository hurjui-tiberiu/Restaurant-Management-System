namespace RestaurantManagementAPI.Application.Models.User
{
    public class UserLoginDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; }
    }
}
