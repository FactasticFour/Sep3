using System.Threading.Tasks;

namespace PresentationLayer.Data
{
    public interface ICreditCardService
    {
        public Task<bool> CheckCreditCard(int id);
        public Task DepositMoney(float amount);
    }
}