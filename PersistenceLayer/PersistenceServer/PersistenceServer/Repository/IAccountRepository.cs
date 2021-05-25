using System.Threading.Tasks;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public interface IAccountRepository
    {
        Task<Account> GetRoleByUsernameAsync(string username);
    }
}