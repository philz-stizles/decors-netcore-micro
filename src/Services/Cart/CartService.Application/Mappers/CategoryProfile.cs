using AutoMapper;
using Cart.Application.Models;
using Cart.Domain.Entities;

namespace Cart.Application.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
