using CatalogService.Application.Contracts.Context;
using CatalogService.Application.Contracts.Repositories;
using CatalogService.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ICatalogDbContext _context;
        public ProductRepository(ICatalogDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);

            return await GetByIdAsync(product.Id);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Products
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context
                            .Products
                            .Find(_ => true)
                            .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _context
                           .Products
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
            var updateResult = await _context
                                 .Products
                                 .ReplaceOneAsync(filter: g => g.Id == product.Id, 
                                    replacement: product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
