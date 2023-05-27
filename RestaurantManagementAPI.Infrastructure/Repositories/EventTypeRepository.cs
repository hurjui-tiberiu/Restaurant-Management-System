using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using RestaurantManagementAPI.Domain.Entities;
using RestaurantManagementAPI.Infrastructure.Interfaces;

namespace RestaurantManagementAPI.Infrastructure.Repositories
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly IConfiguration configuration;

        public EventTypeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task CreateEventType(EventType eventType)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();
                using (OracleCommand command = new OracleCommand(Utilities.createEventTypeQuery, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = eventType.Id;
                    command.Parameters.Add("TITLE", OracleDbType.Varchar2).Value = eventType.Title;
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteEventType(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();
                using (OracleCommand command = new OracleCommand(Utilities.deleteEventTypeQuery, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = id;
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<EventType>> GetAllEvents()
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            List<EventType> eventTypes = new List<EventType>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();
                using (OracleCommand command = new OracleCommand(Utilities.getAllEventTypesQuery, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            EventType eventType = new EventType
                            {
                                Id = new Guid((byte[])reader["ID"]),
                                Title = reader["Title"].ToString()!
                            };
                            eventTypes.Add(eventType);
                        }
                    }
                }
            }
            return eventTypes;
        }

        public async Task<EventType> GetEventTypeById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            var eventType = new EventType();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                
                await connection.OpenAsync();
                using (OracleCommand command = new OracleCommand(Utilities.getEventTypeByIdQuery, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = id;

                    
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            eventType = new EventType
                            {
                                Id = new Guid((byte[])reader["ID"]),
                                Title = reader["Title"].ToString()!
                            };

                        }
                    }
                }
            }

            return eventType;
        }

        public async Task UpdateEventType(EventType eventType)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();
                using (OracleCommand command = new OracleCommand(Utilities.updateEventTypeQuery, connection))
                {
                    command.Parameters.Add("Id", OracleDbType.Raw).Value = eventType.Id;
                    command.Parameters.Add("Title", OracleDbType.Varchar2).Value = eventType.Title;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
