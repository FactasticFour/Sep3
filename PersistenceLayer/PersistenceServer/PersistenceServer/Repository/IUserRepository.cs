using System.Collections.Generic;
using System.Threading.Tasks;
using PersistenceServer.Models;

namespace PersistenceServer.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task RemoveUserAsync(int id);
    }
}