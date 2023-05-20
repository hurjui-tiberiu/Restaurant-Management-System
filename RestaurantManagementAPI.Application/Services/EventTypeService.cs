using AutoMapper;
using RestaurantManagementAPI.Application.Interfaces;
using RestaurantManagementAPI.Application.Models.EventType;
using RestaurantManagementAPI.Domain.Entities;
using RestaurantManagementAPI.Infrastructure.Interfaces;

namespace RestaurantManagementAPI.Application.Services
{
    public class EventTypeService : IEventTypeService
    {
        private readonly IEventTypeRepository eventTypeRepository;
        private readonly IMapper mapper;

        public EventTypeService(IEventTypeRepository eventTypeRepository, IMapper mapper)
        {
            this.eventTypeRepository = eventTypeRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> CreateEventType(EventTypeDto eventTypeDto)
        {
            var eventType = mapper.Map<EventType>(eventTypeDto);
            eventType.Id = Guid.NewGuid();

            await eventTypeRepository.CreateEventType(eventType);

            return eventType.Id;
        }

        public async Task<List<EventType>> GetAllEvents()
        {
            var eventTypes = await eventTypeRepository.GetAllEvents();

            return eventTypes;
        }
    }
}
