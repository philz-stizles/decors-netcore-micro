using CatalogService.Application.Contracts.Context;
using CatalogService.Application.Contracts.Repositories;
using CatalogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ICatalogDbContext _context;

        public CategoryRepository(ICatalogDbContext context)
        {
           _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Category> AddAsync(Category product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Category product)
        {
            throw new NotImplementedException();
        }
    }
}
