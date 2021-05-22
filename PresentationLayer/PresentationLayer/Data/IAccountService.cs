using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data
{
    public interface IAccountService
    {
        Task<ViaEntity> CheckViaAccount(int id, string password);
    }
}