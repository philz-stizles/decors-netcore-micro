using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Infrastructure.Persistence.Context;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataDbContext dbContext) : base(dbContext)
        {
        }
    }
}
