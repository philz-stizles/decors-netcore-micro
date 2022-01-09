using AutoMapper;
using CatalogService.Application.Models.Dtos;
using CatalogService.Application.Models.Requests;
using CatalogService.Domain.Entities;

namespace Auth.Application.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, Product> ()
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
