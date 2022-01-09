using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Infrastructure.Persistence.Context;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class AuditRepository: IAuditRepository
    {
        private readonly DataDbContext _dbContext;
        public AuditRepository(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Audit> AddAsync(Audit entity)
        {
            _dbContext.Audits.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
