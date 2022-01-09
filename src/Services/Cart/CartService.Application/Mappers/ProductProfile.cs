using AutoMapper;
using Cart.Application.Models;
using Cart.Application.Services.Products;
using Cart.Domain.Entities;

namespace Cart.Application.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProduct.Command, Product> ()
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
