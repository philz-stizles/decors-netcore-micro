using CatalogService.Application.Models.Dtos;
using CatalogService.Application.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogService.Application.Contracts.Services.Application
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetById(string productId);
        Task<ProductDto> Create(CreateProductRequest request);
        Task<ProductDto> Update(string productId, CreateProductRequest request);
    }
}
