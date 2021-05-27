using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class AccountRepositoryImpl : IAccountRepository
    {
        public async Task<float> getAcountBalance(int id)
        {
            await using DataContext dataContext = new DataContext();
            Account account = await dataContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            return account.Balance;
        }
    }
}