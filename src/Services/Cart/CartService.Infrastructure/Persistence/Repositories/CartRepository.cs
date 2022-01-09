using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Text.Json;
using System;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IDatabase _redisDb;

        public CartRepository(IConnectionMultiplexer redis)
        {
            _redisDb = redis.GetDatabase();
        }

        public async Task<bool> DeleteCartAsync(string cartId)
        {
            return await _redisDb.KeyDeleteAsync(cartId);
        }

        public async Task<Cart> GetCartAsync(string cartId)
        {
            var data = await _redisDb.StringGetAsync(cartId);
            return (data.IsNullOrEmpty) 
                ? null 
                : JsonSerializer.Deserialize<Cart>(data);
        }

        public async Task<Cart> SaveCartAsync(Cart cart)
        {
            var created = await _redisDb.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart), 
                TimeSpan.FromDays(15));
            return (!created) 
                ? null 
                : await GetCartAsync(cart.Id);
        }
    }
}
