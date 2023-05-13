using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
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
        public async Task Register(User user)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=49161))(CONNECT_DATA=(SID=XE)));User ID=system;Password=oracle;"))
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
    }
}