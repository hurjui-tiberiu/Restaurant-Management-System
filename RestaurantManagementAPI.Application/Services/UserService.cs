using AutoMapper;
using RestaurantManagementAPI.Application.Interfaces;
using RestaurantManagementAPI.Application.Models;
using RestaurantManagementAPI.Domain;
using RestaurantManagementAPI.Domain.Entities;
using RestaurantManagementAPI.Infrastructure.Interfaces;

namespace RestaurantManagementAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Register(UserDto userDto)
        {
            var user = mapper.Map<User>(userDto);

            user.Id = Guid.NewGuid();
            user.Role = Role.User;

            await userRepository.Register(user);

            return user.Id;
        }
    }
}
