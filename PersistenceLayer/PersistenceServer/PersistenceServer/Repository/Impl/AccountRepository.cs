using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<Account> GetRoleByUsernameAsync(string username)
        {
            await using DataContext dataContext = new DataContext();
                Account account = await dataContext.Accounts.Include(account => account.ViaEntity).Include(role => role.AccountType)
                    .FirstOrDefaultAsync(account => account.ViaEntity.ViaId.ToString().Equals(username));

                Console.WriteLine($"Account found username:{account.ViaEntity.ViaId}");
                Console.WriteLine($"Account found AccountID:{account.AccountId}");
                Console.WriteLine($"Account found password:{account.ApplicationPassword}");

                //Role role = await dataContext.Roles.Include(roleTo => roleTo.Account).FirstOrDefaultAsync(roleTo => roleTo.Account.AccountId == include.AccountId);
                Console.WriteLine($"Role found: {account.AccountType} + {account.ViaEntity.ViaId}");
                return account;
            }
    }
}