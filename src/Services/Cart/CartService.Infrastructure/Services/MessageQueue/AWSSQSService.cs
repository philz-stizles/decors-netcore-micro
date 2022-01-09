using Decors.Application.Contracts.Services;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Services.MessageQueue
{
    public class AWSSQSService : IAWSSQSService
    {
        public Task<bool> SendMessageAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
