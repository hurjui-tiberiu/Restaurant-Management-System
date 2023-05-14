using RestaurantManagementAPI.Application.Models;

namespace RestaurantManagementAPI.Application.Interfaces
{
    public interface IUserService
    {
        public Task<Guid> Register(UserRegisterDto userDto);
        public Task<UserGetDto> GetUserById(Guid id);
        public Task DeleteUserById(Guid id);
        public Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto);
        public Task<UserDto> UpdateUser(UserDto userDto, Guid id);
    }
}
