using AutoMapper;
using CatalogService.Application.Contracts.Repositories;
using CatalogService.Application.Contracts.Services.Application;
using CatalogService.Application.Contracts.Services.Infrastructure;
using CatalogService.Application.Exceptions;
using CatalogService.Application.Models.Dtos;
using CatalogService.Application.Models.Requests;
using CatalogService.Domain.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CatalogService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IUserAccessor userAccessor, IProductRepository productRepository,
            ICategoryRepository categoryRepository, IMapper mapper)
        {
            _userAccessor = userAccessor;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Create(CreateProductRequest request)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            // Map product dto to product entity.
            var newProduct = _mapper.Map<Product>(request);

            newProduct.Category = category;

            var product = await _productRepository.AddAsync(newProduct);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> GetById(string productId)
        {
            // Retrieve product if it exists.
            var existingProduct = await _productRepository.GetByIdAsync(productId);
            if (existingProduct == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Product does not exist.");
            }

            return _mapper.Map<ProductDto>(existingProduct);
        }


        public async Task<List<ProductDto>> GetProducts()
        {
            // Retrieve products
            var products = await _productRepository.GetAllAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> Update(string productId, CreateProductRequest request)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productId);
            if (existingProduct == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Product does not exist");
            }

            // Map updated product dto to product entity.
            var updatedProduct = _mapper.Map<Product>(request);

            // Create new product.
            await _productRepository.UpdateAsync(updatedProduct);

            return _mapper.Map<ProductDto>(request);// Map category dto to category entity.
        }
    }
}
