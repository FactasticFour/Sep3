using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data
{
    public interface ITransactionService
    {
        Task<Transaction> SendTransaction(Transaction transaction);
    }
}