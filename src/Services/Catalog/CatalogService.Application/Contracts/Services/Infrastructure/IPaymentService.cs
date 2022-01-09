using Auth.Domain.Entities;
using System.Threading.Tasks;

namespace Auth.Application.Contracts.Services
{
    public interface IPaymentService
    {
        Task<Cart> SavePaymentIntent(string cartId);
    }
}
