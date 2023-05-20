using RestaurantManagementAPI.Domain.Entities;

namespace RestaurantManagementAPI.Infrastructure.Interfaces
{
    public interface IEventTypeRepository
    {
        public Task CreateEventType(EventType eventType);
        public Task<List<EventType>> GetAllEvents();
    }
}
