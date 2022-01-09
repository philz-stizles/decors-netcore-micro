using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class VendorRepository: RepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(DataDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Vendor> GetByIdIncludeUser(int vendorId)
        {
            IQueryable<Vendor> query = _dbContext.Set<Vendor>();

            query = query.Include(v => v.Users).ThenInclude(vu => vu.User);

            query = query.Where(v => v.Id == vendorId);

            return await query.SingleOrDefaultAsync();
        }
    }
}
