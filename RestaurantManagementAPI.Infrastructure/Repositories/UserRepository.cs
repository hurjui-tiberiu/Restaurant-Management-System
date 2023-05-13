using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using RestaurantManagementAPI.Domain;
using RestaurantManagementAPI.Domain.Entities;
using RestaurantManagementAPI.Infrastructure.Interfaces;

namespace RestaurantManagementAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;

        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<User?> GetUserById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Utilities.getUserQuery, connection))
                {
                    command.Parameters.Add("userId", OracleDbType.Raw).Value = id;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            User user = new User
                            {
                                Id = new Guid((byte[])reader["ID"]),
                                FirstName = reader["FirstName"].ToString()!,
                                LastName = reader["LastName"].ToString()!,
                                EmailAddress = reader["EmailAddress"].ToString()!,
                                Password = reader["Password"].ToString()!,
                                PhoneNumber = reader["PhoneNumber"].ToString()!,
                                Address = reader["Address"].ToString()!,
                                Role = (Role)(short)reader["Role"]
                            };

                            return user;
                        }
                    }
                }
            }

            return null;
        }

        public async Task Register(User user)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Utilities.createUserQuery, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = user.Id;
                    command.Parameters.Add("FirstName", OracleDbType.NVarchar2).Value = user.FirstName;
                    command.Parameters.Add("LastName", OracleDbType.NVarchar2).Value = user.LastName;
                    command.Parameters.Add("EmailAddress", OracleDbType.NVarchar2).Value = user.EmailAddress;
                    command.Parameters.Add("Password", OracleDbType.NVarchar2).Value = user.Password;
                    command.Parameters.Add("PhoneNumber", OracleDbType.NVarchar2).Value = user.PhoneNumber;
                    command.Parameters.Add("Address", OracleDbType.NVarchar2).Value = user.Address;
                    command.Parameters.Add("Role", OracleDbType.Int32).Value = user.Role;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteUserById(Guid userId)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM \"User\" WHERE ID = :ID";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = userId;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();
                using (OracleCommand command = new OracleCommand(Utilities.getUserByEmailQuery, connection))
                {
                    command.Parameters.Add("EmailAddress", OracleDbType.NVarchar2).Value = email;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            User user = new User
                            {
                                Id = new Guid((byte[])reader["ID"]),
                                FirstName = reader["FirstName"].ToString()!,
                                LastName = reader["LastName"].ToString()!,
                                EmailAddress = reader["EmailAddress"].ToString()!,
                                Password = reader["Password"].ToString()!,
                                PhoneNumber = reader["PhoneNumber"].ToString()!,
                                Address = reader["Address"].ToString()!,
                                Role = (Role)(short)reader["Role"]
                            };
                            return user;
                        }
                    }
                }
            }
            return null;
        }
    }
}