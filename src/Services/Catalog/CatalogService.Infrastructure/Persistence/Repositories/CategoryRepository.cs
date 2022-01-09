using CatalogService.Application.Contracts.Context;
using CatalogService.Application.Contracts.Repositories;
using System;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ICatalogDbContext _context;

        public CategoryRepository(ICatalogDbContext context)
        {
           _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
