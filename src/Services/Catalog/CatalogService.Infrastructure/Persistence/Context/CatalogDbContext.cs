using CatalogService.Application.Contracts.Context;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence.Seeding;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CatalogService.Infrastructure.Persistence.Context
{
    public class CatalogDbContext: ICatalogDbContext
    {
        public CatalogDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogSeeder.Seed(Products);
        }

        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<Category> Categories { get; }
    }
}
