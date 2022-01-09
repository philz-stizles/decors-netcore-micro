using Decors.Domain.Entities;
using Decors.Domain.Enums;
using Decors.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Persistence.Seeding
{
    public class Seeder
    {

        public static async Task Seed(UserManager<User> userManager, RoleManager<Role> roleManager, 
            DataDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                // Seed users.
                await SeedRolesAsync(roleManager);

                // Seed users.
                await SeedUsersAsync(userManager);

                // Seed delivery methods.
                await SeedDeliveryMethodsAsync(context);
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<Seeder>();
                logger.LogError(ex, "An error occured while seeding");
            }
        }

        public static async Task SeedUsersAsync(UserManager<User> userManager)
        {
            // Create seed users
            var seedUser = new User
            {
                UserName = "Admin",
                Email = "theophilusighalo@gmail.com",
                EmailConfirmed = true
            };
            
            if ((await userManager.FindByNameAsync(seedUser.UserName)) == null)
            {
                var result = await userManager.CreateAsync(seedUser, "P@ssw0rd");
                if (result.Succeeded)
                {
                    var newUser = userManager.FindByNameAsync(seedUser.UserName).Result;
                    await userManager.AddToRolesAsync(newUser, new[] { "Admin" });
                }
            }
        }

        public static async Task SeedUsersFromJson(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            await SeedRolesAsync(roleManager);
            var json = File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(json);

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "P@ssw0rd");
                await userManager.AddToRoleAsync(user, "Member");
            }
        }

        public static async Task SeedDeliveryMethodsAsync(DataDbContext context)
        {
            if (!context.DeliveryMethods.Any())
            {
                var deliveryMethodsSeedLocation = "../Decors.Infrastructure/Persistence/Seeding/Data/delivery.json";  // Path should be the location
                var serializedDeliveryMethods = File.ReadAllText(deliveryMethodsSeedLocation);
                var deliveryMethods = System.Text.Json.JsonSerializer
                    .Deserialize<IReadOnlyList<DeliveryMethod>>(serializedDeliveryMethods);

                await context.DeliveryMethods.AddRangeAsync(deliveryMethods);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedRolesAsync(RoleManager<Role> roleManager)
        {
            var roles = new List<Role>{
                new Role{ Name = RoleTypes.Admin.ToString()},
                new Role{ Name = RoleTypes.Vendor.ToString()},
                new Role{ Name = RoleTypes.Customer.ToString()},
            };

            foreach (var role in roles)
            {
                if (!(await roleManager.RoleExistsAsync(role.Name)))
                {
                    await roleManager.CreateAsync(role);
                    /*await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, "projects.view"));
                    await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, "projects.create"));
                    await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, "projects.update"));*/
                }
            }
        }

        private static IEnumerable<User> GetPreconfiguredUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserName = "Admin",
                    Email = "theophilusighalo@gmail.com",
                    EmailConfirmed = true
                }
            };
        }
    }
}
