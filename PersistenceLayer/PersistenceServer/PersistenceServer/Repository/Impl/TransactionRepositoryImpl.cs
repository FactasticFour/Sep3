using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class TransactionRepositoryImpl : ITransactionRepository
    {
        public async Task<Account> GetAccountByAccountID(int accountid)
        {
            using DataContext dataContext = new DataContext();
            Account account = await dataContext.Accounts.FirstAsync(x => x.AccountId == accountid);
            return account;
        }
    }
}