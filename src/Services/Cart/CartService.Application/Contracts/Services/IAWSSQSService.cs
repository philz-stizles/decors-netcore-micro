using System.Threading.Tasks;

namespace Cart.Application.Contracts.Services
{
    public interface IAWSSQSService
    {
        Task<bool> SendMessageAsync();
    }
}
