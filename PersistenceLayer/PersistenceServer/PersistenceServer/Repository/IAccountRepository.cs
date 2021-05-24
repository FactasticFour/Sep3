using System.Threading.Tasks;
using PersistenceServer.Models;

namespace PersistenceServer.Repository
{
    public interface IAccountRepository
    {
        Task<ViaEntity> GetViaEntityByIdAsync(int id);
        Task<Member> GetViaMemberByIdAsync(int id);
        Task<Facility> GetViaFacilityByIdAsync(int id);
    }
}