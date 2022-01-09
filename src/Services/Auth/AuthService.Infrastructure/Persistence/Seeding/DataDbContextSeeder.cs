using Decors.Domain.Entities;
using Decors.Infrastructure.Persistence.Context;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Persistence.Seeding
{
    public class DataDbContextSeeder
    {
        public static async Task SeedAsync(DataDbContext dataDbContext, ILogger<DataDbContextSeeder> logger)
        {
            if (!dataDbContext.Permissions.Any())
            {
                dataDbContext.Permissions.AddRange(GetPreconfiguredPermissions());
                await dataDbContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(DataDbContext).Name);
            }
        }

        private static IEnumerable<Permission> GetPreconfiguredPermissions()
        {
            return new List<Permission>
            {
                new Permission() { }
            };
        }
    }
}
