using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class AccountRepositoryImpl : IAccountRepository
    {
        public async Task<ViaEntity> GetViaEntityByIdAsync(int id)
        {
            using DataContext dataContext = new DataContext();
            Member member = await dataContext.Members.FirstOrDefaultAsync(m => m.ViaId == id);
            if (member != null)
            {
                return member;
            }
            else
            {
                Facility facility = await dataContext.Facilities.FirstOrDefaultAsync(f => f.ViaId == id);
                if (facility != null)
                {
                    return facility;
                }
            }

            return null;
        }
        
        public async Task<Member> GetViaMemberByIdAsync(int id)
        {
            Console.WriteLine("repository looking for member");
            using DataContext dataContext = new DataContext();
            Member member = await dataContext.Members.FirstOrDefaultAsync(m => m.ViaId == id);
            return member;
        }

        public async Task<Facility> GetViaFacilityByIdAsync(int id)
        {
            Console.WriteLine("repository looking for facility");
            using DataContext dataContext = new DataContext();
            Facility facility = await dataContext.Facilities.FirstOrDefaultAsync(f => f.ViaId == id);
            return facility;
        }
    }
}