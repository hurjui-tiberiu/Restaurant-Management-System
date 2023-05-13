﻿using RestaurantManagementAPI.Application.Models;

namespace RestaurantManagementAPI.Application.Interfaces
{
    public interface IUserService
    {
        public Task<Guid> Register(UserDto userDto);
        public Task<UserGetDto> GetUserById(Guid id);
        public Task DeleteUserById(Guid id);
        public Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto);
    }
}
