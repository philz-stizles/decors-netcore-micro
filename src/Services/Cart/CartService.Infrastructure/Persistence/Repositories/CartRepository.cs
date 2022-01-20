using System.Threading.Tasks;
using System.Text.Json;
using System;
using Microsoft.Extensions.Caching.Distributed;
using CartService.Domain.Entities;
using CartService.Application.Contracts.Repositories;
using Newtonsoft.Json;

namespace CartService.Infrastructure.Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IDistributedCache _redisCache;

        public CartRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<Cart> GetAsync(string userName)
        {
            var cart = await _redisCache.GetStringAsync(userName);
            return (String.IsNullOrEmpty(cart)) 
                ? null 
                : JsonConvert.DeserializeObject<Cart>(cart);
        }

        public async Task<Cart> SaveAsync(Cart cart)
        {
            await _redisCache.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));
            return await GetAsync(cart.UserName);
        }

        public async Task DeleteAsync(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
    }
}
