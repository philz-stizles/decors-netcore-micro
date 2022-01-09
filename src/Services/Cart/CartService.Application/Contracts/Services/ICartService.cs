using Cart.Application.Models.Dtos;
using System.Threading.Tasks;

namespace Cart.Application.Contracts.Services
{
    public interface ICartService
    {
        Task<CartDto> GetCartAsync(string cartId);
        Task<CartDto> SaveCartAsync(CartSaveDto cartSaveDto);
        Task<bool> DeleteCartAsync(string cartId);
    }
}
