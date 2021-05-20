using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class CreditCardRepositoryImpl : ICreditCardRepository
    {

        public async Task AddCreditCardToAccount(CreditCard creditCard)
        {
            await using DataContext dataContext = new DataContext();
            Account account = dataContext.Accounts.FirstOrDefault(x => x.AccountId.Equals(creditCard.Account.AccountId));
            creditCard.Account = account;
            
            await dataContext.CreditCards.AddAsync(creditCard);
            await dataContext.SaveChangesAsync();
        }
    }
}