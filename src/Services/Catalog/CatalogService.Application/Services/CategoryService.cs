using AutoMapper;
using CatalogService.Application.Contracts.Repositories;
using CatalogService.Application.Contracts.Services.Application;
using CatalogService.Application.Contracts.Services.Infrastructure;
using CatalogService.Application.Models.Dtos;
using CatalogService.Application.Models.Requests;
using CatalogService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogService.Application.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IUserAccessor userAccessor, ICategoryRepository categoryRepository, 
            IMapper mapper)
        {
            _userAccessor = userAccessor;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Create(CategoryRequest request)
        {
            // Map category dto to category entity.
            var newCategory = _mapper.Map<Category>(request);

            var category = await _categoryRepository.AddAsync(newCategory);

            return _mapper.Map<CategoryDto>(category);
        }

        public Task<List<CategoryDto>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryDto> GetById(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryDto> Update(int productId, CategoryRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
