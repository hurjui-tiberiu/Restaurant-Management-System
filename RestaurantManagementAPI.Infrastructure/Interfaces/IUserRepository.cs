using RestaurantManagementAPI.Domain.Entities;

namespace RestaurantManagementAPI.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        public Task Register(User user);
        public Task<User?> GetUserById(Guid id);
        public Task DeleteUserById(Guid id);
        public Task<User?> GetUserByEmail(string email);
    }
}
