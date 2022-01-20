using AutoMapper;
using CartService.Application.Models.Dtos;
using Decors.EventBus.Events;

namespace CartService.Application.Mappers
{
    public class CheckoutProfile : Profile
    {
        public CheckoutProfile()
        {
            CreateMap<CartCheckoutDto, CartCheckoutEvent>().ReverseMap();
        }
    }
}
