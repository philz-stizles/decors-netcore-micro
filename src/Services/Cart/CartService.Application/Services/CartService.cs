using AutoMapper;
using CartService.Application.Contracts.Repositories;
using CartService.Application.Contracts.Services;
using CartService.Application.Exceptions;
using CartService.Application.Models.Dtos;
using CartService.Domain.Entities;
using Decors.EventBus.Events;
using MassTransit;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CartService.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public CartService(ICartRepository cartRepository, IMapper mapper,
            IPublishEndpoint publishEndpoint)
        {
            _cartRepository = cartRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public async Task<CartDto> GetAsync(string userName)
        {
            var cart = await _cartRepository.GetAsync(userName);

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> SaveAsync(CartSaveDto dto)
        {
            var cart = _mapper.Map<Cart>(dto);

            var savedCart = await _cartRepository.SaveAsync(cart);

            return _mapper.Map<CartDto>(savedCart);
        }

        public async Task DeleteAsync(string userName)
        {
            await _cartRepository.DeleteAsync(userName);
        }

        public async Task CheckoutAsync(CartCheckoutDto checkoutDto)
        {
            // get existing basket with total price            
            // Set TotalPrice on basketCheckout eventMessage
            // send checkout event to rabbitmq
            // remove the basket

            // get existing basket with total price
            var cart = await _cartRepository.GetAsync(checkoutDto.UserName);
            if (cart == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, new { 
                    Status = false,
                    Message = "You do not have any cart"
                });
            }

            // send checkout event to rabbitmq
            var eventMessage = _mapper.Map<CartCheckoutEvent>(checkoutDto);
            eventMessage.TotalPrice = cart.TotalPrice;
            await _publishEndpoint.Publish<CartCheckoutEvent>(eventMessage);

            // remove the basket
            await _cartRepository.DeleteAsync(cart.UserName);
        }
    }
}
