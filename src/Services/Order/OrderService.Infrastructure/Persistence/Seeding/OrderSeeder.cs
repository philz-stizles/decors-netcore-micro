using Microsoft.Extensions.Logging;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistence.Seeding
{
    public class OrderSeeder
    {
        public static async Task SeedAsync(OrderDbContext orderContext, 
            ILogger<OrderSeeder> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", 
                    typeof(OrderDbContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() { 
                    UserName = "swn", 
                    FirstName = "Mehmet", 
                    LastName = "Ozkaya", 
                    EmailAddress = "ezozkme@gmail.com", 
                    AddressLine = "Bahcelievler", 
                    Country = "Turkey", 
                    TotalPrice = 350 
                }
            };
        }
    }
}
