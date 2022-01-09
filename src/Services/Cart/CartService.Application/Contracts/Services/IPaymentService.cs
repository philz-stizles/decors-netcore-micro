using Cart.Domain.Entities;
using System.Threading.Tasks;

namespace Cart.Application.Contracts.Services
{
    public interface IPaymentService
    {
        Task<Cart> SavePaymentIntent(string cartId);
    }
}
