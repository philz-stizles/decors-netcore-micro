using AutoMapper;
using Cart.Application.Models;
using Cart.Domain.Entities;

namespace Cart.Application.Mappers
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
