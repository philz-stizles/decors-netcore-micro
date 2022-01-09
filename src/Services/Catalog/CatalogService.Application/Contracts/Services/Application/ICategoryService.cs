using CatalogService.Application.Models.Dtos;
using CatalogService.Application.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogService.Application.Contracts.Services.Application
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> Get();
        Task<CategoryDto> GetById(int productId);
        Task<CategoryDto> Create(CategoryRequest request);
        Task<CategoryDto> Update(int productId, CategoryRequest request);
    }
}
