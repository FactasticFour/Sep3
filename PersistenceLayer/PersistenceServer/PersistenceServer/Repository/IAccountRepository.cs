using System.Threading.Tasks;
using PersistenceServer.Models;

namespace PersistenceServer.Repository
{
    public interface IAccountRepository
    {
        Task<ViaEntity> GetViaEntityWithIdAsync(int id);
    }
}