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
            try
            {
                Account account =
                    dataContext.Accounts.First(x => x.AccountId.Equals(creditCard.Account.AccountId));
                creditCard.Account = account;
                Console.WriteLine(creditCard.CreditCardNumber);
                Console.WriteLine(creditCard.Account.AccountId);
                Console.WriteLine(creditCard.Account.ApplicationPassword);
                await dataContext.CreditCards.AddAsync(creditCard);
                await dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Credit card for this account could not be added");
            }
        }
    }
}