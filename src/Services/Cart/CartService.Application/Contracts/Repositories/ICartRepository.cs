using CartService.Domain.Entities;
using System.Threading.Tasks;

namespace CartService.Application.Contracts.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetAsync(string userName);

        Task<Cart> SaveAsync(Cart cart);

        Task DeleteAsync(string userName);
    }
}
