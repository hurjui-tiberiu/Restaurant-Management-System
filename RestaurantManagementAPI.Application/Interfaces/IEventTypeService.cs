using RestaurantManagementAPI.Application.Models.EventType;
using RestaurantManagementAPI.Domain.Entities;

namespace RestaurantManagementAPI.Application.Interfaces
{
    public interface IEventTypeService
    {
        public Task<Guid> CreateEventType(EventTypeDto eventType);
        public Task<List<EventType>> GetAllEvents();
    }
}
