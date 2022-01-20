using CatalogService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogService.Application.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(string id);
        Task<Category> GetByName(string name);
        Task<Category> AddAsync(Category product);
        Task<bool> UpdateAsync(Category product);
        Task<bool> DeleteAsync(string id);
    }
}
