using AutoMapper;
using RestaurantManagementAPI.Application.Models.EventType;
using RestaurantManagementAPI.Domain.Entities;

namespace RestaurantManagementAPI.Application.Mapper
{
    public class EventTypeProfile:Profile
    {
        public EventTypeProfile()
        {
            CreateMap<EventTypeDto, EventType>();
            CreateMap<EventType, EventTypeDto>();
        }
    }
}
