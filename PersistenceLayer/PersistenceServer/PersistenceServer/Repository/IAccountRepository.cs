using System.Threading.Tasks;

namespace PersistenceServer.Repository
{
    public interface IAccountRepository
    {
        Task<float> getAcountBalance(int id);
    }
}