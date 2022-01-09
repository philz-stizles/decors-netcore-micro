using Auth.Domain.Entities;
using System.Threading.Tasks;

namespace Auth.Application.Contracts.Repositories
{
    public interface IAuditRepository
    {
        Task<Audit> AddAsync(Audit entity);
    }
}
