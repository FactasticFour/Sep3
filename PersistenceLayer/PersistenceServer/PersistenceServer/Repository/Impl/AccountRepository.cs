using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            Console.WriteLine($"Username from handler: {username}");
            await using DataContext dataContext = new DataContext();
            Account account;
            
            try
            {
                account = await dataContext.Accounts.Include(c => c.ViaEntity).Include(a => a.AccountType)
                    .FirstOrDefaultAsync(a => a.ViaEntity.ViaId.ToString().Equals(username));
            }
            catch (Exception e)
            {
                throw new Exception($"Account with username {username} could not be found");
            }

            Console.WriteLine($"Account found username:{account.ViaEntity.ViaId}");
            Console.WriteLine($"Account found AccountID:{account.AccountId}");
            Console.WriteLine($"Account found password:{account.ApplicationPassword}");
            Console.WriteLine($"Account found with role:{account.AccountType.RoleType}");
            Console.WriteLine(account);
            
            return account;
        }
    }
}