using Cart.Domain.Entities;
using System.Threading.Tasks;

namespace Cart.Application.Contracts.Repositories
{
    public interface IAuditRepository
    {
        Task<Audit> AddAsync(Audit entity);
    }
}
