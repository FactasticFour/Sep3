using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersistenceServer.Repository
{
    public interface IRoleRepository
    {
        Task<List<string>> GetAllAccountTypesAsync();
    }
}