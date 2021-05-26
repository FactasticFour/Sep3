using System.Threading.Tasks;

namespace PresentationLayer.Data
{
    public interface IAccountService
    {
        Task<float> getAccountBalance(int id);
    }
}