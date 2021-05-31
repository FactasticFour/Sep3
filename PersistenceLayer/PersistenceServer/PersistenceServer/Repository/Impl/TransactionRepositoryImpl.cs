using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class TransactionRepositoryImpl : ITransactionRepository
    {
        public async Task<Account> GetAccountByAccountID(int accountid)
        {
            try
            {
                using DataContext dataContext = new DataContext();
                Account account = await dataContext.Accounts.FirstAsync(x => x.AccountId == accountid);
                return account;
            }
            catch (Exception e)
            {
                throw new Exception("Account could not be updated");
            }
        }

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            using DataContext dataContext = new DataContext();

            try
            {
                EntityEntry<Transaction> entityEntry = await dataContext.Transactions.AddAsync(transaction);
                Transaction transactionAdded = entityEntry.Entity;
                return transaction;
            }
            catch (Exception e)
            {
                throw new Exception("Transaction could not be added");
            }
        }
    }
}