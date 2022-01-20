using CartService.Application.Contracts.Services;
using CartService.Application.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace CartService.API.Controllers
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
        public async Task<ActionResult<CartDto>> SaveCart([FromBody]CartSaveDto dto)
        {

            var result = await _cartService.SaveAsync(dto);
            return Ok(result);
        }


        [HttpGet("{userName}", Name = "GetCart")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CartDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CartDto))]
        public async Task<ActionResult<CartDto>> GetCart([FromRoute]string userName)
        {
            var result = await _cartService.GetAsync(userName);
            return Ok(result ?? new CartDto(userName));
        }


        [HttpDelete("{userName}", Name = "DeleteCart")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        public async Task<IActionResult> DeleteCart(string userName)
        {
            await _cartService.DeleteAsync(userName);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] CartCheckoutDto checkoutDto)
        {

            await _cartService.CheckoutAsync(checkoutDto);
            return Accepted();
        }
    }
}
