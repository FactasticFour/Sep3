using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
    }
}