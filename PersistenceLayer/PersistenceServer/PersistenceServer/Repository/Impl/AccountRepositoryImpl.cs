using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class AccountRepositoryImpl : IAccountRepository
    {
        public async Task<Account> GetAccountWithViaId(int viaId)
        {
            Console.WriteLine($"*** looking for account with id: {viaId}");
            using DataContext dataContext = new DataContext();
            Account account;
            try
            {
                account = await dataContext.Accounts.FirstAsync(a => a.ViaEntity.ViaId == viaId);
                Console.WriteLine("found account");
            }
            catch (Exception e)
            {
                Console.WriteLine("throwing exception");
                throw new Exception($"Account with via id {viaId} does not exist");
            }
            
            return account;
        }

        public async Task AddAccountAsync(Account accountToAdd)
        {
            using DataContext dataContext = new DataContext();

            Role r = await dataContext.Roles.FirstOrDefaultAsync(r => r.RoleId == accountToAdd.AccountType.RoleId);
            accountToAdd.AccountType = r;

            ViaEntity ve = await dataContext.ViaEntities.FirstOrDefaultAsync(ve => ve.ViaId == accountToAdd.ViaEntity.ViaId);
            accountToAdd.ViaEntity = ve;
            
            await dataContext.Accounts.AddAsync(accountToAdd);
            
            await dataContext.SaveChangesAsync();

            Account a = await dataContext.Accounts.FirstOrDefaultAsync(a =>
                a.ViaEntity.ViaId == accountToAdd.ViaEntity.ViaId);
            
            await dataContext.ViaEntities.AddAsync(ve);
            await dataContext.SaveChangesAsync();
            
            Console.WriteLine("hope this worked");
        }
    }
}