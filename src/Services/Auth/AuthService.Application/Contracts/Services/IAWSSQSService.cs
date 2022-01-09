using System.Threading.Tasks;

namespace Auth.Application.Contracts.Services
{
    public interface IAWSSQSService
    {
        Task<bool> SendMessageAsync();
    }
}
