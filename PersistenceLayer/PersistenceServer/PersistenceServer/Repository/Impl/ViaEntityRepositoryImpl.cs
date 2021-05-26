using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class ViaEntityRepositoryImpl : IViaEntityRepository
    {
        public async Task<ViaEntity> GetViaEntityWithIdAsync(int id)
        {
            using DataContext dataContext = new DataContext();
            ViaEntity viaEntity = await dataContext.ViaEntities.FirstOrDefaultAsync(ve => ve.ViaId == id);
            return viaEntity;
        }
    }
}