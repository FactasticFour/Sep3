using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository
{
    public class UserRepositoryImpl : IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUserAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            await using DataContext dataContext = new DataContext();
            return await dataContext.Users.FirstOrDefaultAsync(user => id == user.UserId);
            //TODO Catch exception
        }

        public Task AddUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}