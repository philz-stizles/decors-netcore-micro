using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.API.Extensions
{
    public static class CorsServicesExtension
    {
        public static IServiceCollection AddCorsServices(this IServiceCollection services,
            IConfiguration Configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("BasePolicy", policy =>
                {
                    var allowedOrigins = Configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>();
                    policy
                        .WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCorsServices(this IApplicationBuilder app)
        {
            app.UseCors("BasePolicy");

            return app;
        }
    }
}
