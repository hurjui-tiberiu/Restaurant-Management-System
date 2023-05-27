using Microsoft.AspNetCore.Mvc;
using RestaurantManagementAPI.Application.Interfaces;
using RestaurantManagementAPI.Application.Models.EventType;
using RestaurantManagementAPI.Domain.Entities;

namespace RestaurantManagementAPI.Controllers
{
    [ApiController]
    public class EventTypeController:ControllerBase
    {
        private readonly IEventTypeService eventTypeService;

        public EventTypeController(IEventTypeService eventTypeService)
        {
            this.eventTypeService = eventTypeService;
        }

        [HttpPost("eventtypes")]
        public async Task<IActionResult> CreateEventType(EventTypeDto eventType)
        {
            var eventTypeId = await eventTypeService.CreateEventType(eventType);

            return Ok(eventTypeId);
        }

        [HttpGet("eventtypes")]
        public async Task<IActionResult> GetAllEvents()
        {
            var eventTypes = await eventTypeService.GetAllEvents();

            return Ok(eventTypes);
        }

        [HttpGet("eventtypes/{id}")]
        public async Task<IActionResult> GetEventTypeById(Guid id)
        {
            var eventType = await eventTypeService.GetEvent(id);

            
            return Ok(eventType);
        }

        [HttpDelete("eventtypes/{id}")]
        public async Task<IActionResult> DeleteEventType(Guid id)
        {
            await eventTypeService.DeleteEvent(id);

            return Ok();
        }

        [HttpPut("eventtypes/{id}")]
        public async Task<IActionResult> UpdateEventType(EventTypeDto eventType, Guid id)
        {
            var eventTypeId = await eventTypeService.UpdateEventType(eventType, id);

            return Ok(eventTypeId);
        }

    }
}
 