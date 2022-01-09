using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Infrastructure.Persistence.Context;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository: RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DataDbContext dbContext) : base(dbContext)
        {

        }
    }
}
