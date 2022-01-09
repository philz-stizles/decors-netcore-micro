using AutoMapper;
using Cart.Application.Models;
using Cart.Application.Services.Vendors.Coupons;
using Cart.Application.Services.Vendors.Products;
using Cart.Domain.Entities;

namespace Cart.Application.Mappers
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<CreateProduct.Command, Product> ()
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<CreateCoupon.Command, Coupon>();
                // .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
