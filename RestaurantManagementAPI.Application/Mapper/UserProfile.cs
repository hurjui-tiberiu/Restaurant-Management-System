using AutoMapper;
using RestaurantManagementAPI.Application.Models.User;
using RestaurantManagementAPI.Domain.Entities;

namespace RestaurantManagementAPI.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();

            CreateMap<User, UserGetDto>();

            CreateMap<User, UserLoginResponseDto>()
                .ForMember(dest => dest.userRole,
                                   opt => opt.MapFrom(src => src.Role.ToString()));

            CreateMap<User, UserDto>();

            CreateMap<UserRegisterDto, User>();
        }
    }
}
