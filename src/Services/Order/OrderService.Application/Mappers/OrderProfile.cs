using AutoMapper;
using CatalogService.Application.Models.Dtos;
using OrderService.Domain.Entities;

namespace OrderService.Application.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
