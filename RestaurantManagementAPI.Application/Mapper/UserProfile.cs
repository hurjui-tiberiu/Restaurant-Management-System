using AutoMapper;
using RestaurantManagementAPI.Application.Models;
using RestaurantManagementAPI.Domain.Entities;

namespace RestaurantManagementAPI.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
            
            CreateMap<User, UserGetDto>();
        }
    }
}
