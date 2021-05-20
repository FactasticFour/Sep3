using System.Threading.Tasks;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class CreditCardRepositoryImpl : ICreditCardRepository
    {

        public async Task AddCreditCardToAccount(CreditCard creditCard)
        {
            await using DataContext dataContext = new DataContext();
            dataContext.CreditCards.Add(creditCard);
            await dataContext.SaveChangesAsync();
        }
    }
}