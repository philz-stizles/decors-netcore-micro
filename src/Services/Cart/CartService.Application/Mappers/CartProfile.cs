using AutoMapper;
using Cart.Application.Models.Dtos;
using Cart.Application.Services.Cart;
using Cart.Domain.Entities;

namespace Cart.Application.Mappers
{
    public class CartProfile: Profile
    {
        public CartProfile()
        {
            CreateMap<SaveCart.Command, Cart>();
            CreateMap<Cart, CartDto>();
            CreateMap<CartItemDto, CustomerCartItem>();
        }
    }
}
