using AutoMapper;
using Decors.EventBus.Events;
using OrderService.Application.Handlers.Orders.Commands;

namespace OrderService.Application.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CheckoutOrderCommand, CartCheckoutEvent>().ReverseMap();
        }
    }
}
