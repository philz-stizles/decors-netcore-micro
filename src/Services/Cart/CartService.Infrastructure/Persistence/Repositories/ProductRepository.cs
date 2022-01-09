using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Infrastructure.Persistence.Context;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class ProductRepository: RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DataDbContext dbContext) : base(dbContext)
        {
        }
    }
}
