namespace RestaurantManagementAPI.Application.Models.User
{
    public class UserLoginResponseDto
    {
        public Guid Id { get; set; }
        public string userRole { get; set; } = null!;
    }
}
