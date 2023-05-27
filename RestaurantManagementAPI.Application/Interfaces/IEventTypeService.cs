using RestaurantManagementAPI.Application.Models.EventType;
using RestaurantManagementAPI.Domain.Entities;

namespace RestaurantManagementAPI.Application.Interfaces
{
    public interface IEventTypeService
    {
        public Task<Guid> CreateEventType(EventTypeDto eventType);
        public Task<List<EventType>> GetAllEvents();
        public Task<EventType> GetEvent(Guid id);
        public Task DeleteEvent(Guid id);
        public Task<Guid> UpdateEventType(EventTypeDto eventType, Guid id);
    }
}
