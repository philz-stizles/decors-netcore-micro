using Cart.Application.Contracts.Services;
using Cart.Application.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cart.API.Controllers
{
    public class CartController: BaseController
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService) {
            _cartService = cartService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CartDto))]
        public async Task<IActionResult> SaveCart([FromBody]CartSaveDto dto)
        {

            var result = await _cartService.SaveCartAsync(dto);
            return Ok(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CartDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CartDto))]
        public async Task<IActionResult> GetCart([FromRoute]string id)
        {
            var result = await _cartService.GetCartAsync(id);
            return Ok(result ?? new CartDto(id));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(string id)
        {
            var result = await _cartService.DeleteCartAsync(id);
            return Ok(result);
        }
    }
}
