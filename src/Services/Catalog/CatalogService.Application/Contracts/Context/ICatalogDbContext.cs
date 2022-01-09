using CatalogService.Domain.Entities;
using MongoDB.Driver;

namespace CatalogService.Application.Contracts.Context
{
    public interface ICatalogDbContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<Category> Categories { get; }
    }
}
