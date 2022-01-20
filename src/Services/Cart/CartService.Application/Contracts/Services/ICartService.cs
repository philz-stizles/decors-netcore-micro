
using CartService.Application.Models.Dtos;
using System.Threading.Tasks;

namespace CartService.Application.Contracts.Services
{
    public interface ICartService
    {
        Task<CartDto> GetAsync(string userName);

        Task<CartDto> SaveAsync(CartSaveDto cart);

        Task DeleteAsync(string userName);

        Task CheckoutAsync(CartCheckoutDto checkoutDto);
    }
}
