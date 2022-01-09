using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Infrastructure.Persistence.Context;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class CouponRepository: RepositoryBase<Coupon>, ICouponRepository
    {
        public CouponRepository(DataDbContext dbContext) : base(dbContext)
        {
        }
    }
}
