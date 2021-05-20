using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data
{
    public interface ICreditCardService
    {
        Task AddCreditCardToAccount(CreditCard creditCard);
    }
}