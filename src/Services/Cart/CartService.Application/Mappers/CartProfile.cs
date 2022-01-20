using AutoMapper;
using CartService.Application.Models.Dtos;
using CartService.Domain.Entities;

namespace CartService.Application.Mappers
{
    public class CartProfile: Profile
    {
        public CartProfile()
        {
            CreateMap<CartDto, Cart>().ReverseMap();
        }
    }
}
