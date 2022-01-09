using AutoMapper;
using CatalogService.Application.Models.Dtos;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
