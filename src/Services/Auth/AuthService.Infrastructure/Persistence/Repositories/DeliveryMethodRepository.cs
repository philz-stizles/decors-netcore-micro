using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Infrastructure.Persistence.Context;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class DeliveryMethodRepository: RepositoryBase<DeliveryMethod>, IDeliveryMethodRepository
    {
        public DeliveryMethodRepository(DataDbContext dbContext) : base(dbContext)
        {
        }
    }
}
