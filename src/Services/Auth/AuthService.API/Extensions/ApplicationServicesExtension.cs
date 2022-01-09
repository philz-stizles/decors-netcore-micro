using Decors.API.Filters;
using Decors.Application.Mappers;
using Decors.Application.Services.Auth;
using Hangfire;
using Hangfire.SqlServer;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;

namespace AuthService.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddScoped<AuditFilterAttribute>();

            services.AddAutoMapper(typeof(UserProfile).Assembly);
            // services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // services.AddAutoMapper(typeof(Startup));

            // services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(RegisterVendor.Handler).Assembly);

            // Add Hangfire services.
            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));
            // Add the processing server as IHostedService
            services.AddHangfireServer();

            services.AddSignalR();

            return services;
        }

        public static IApplicationBuilder UseApplicationServices(
            this IApplicationBuilder app
            /*IWebHostEnvironment env, 
            IConfiguration configuration,
            IServiceProvider serviceProvider,
            IRecurringJobManager recurringJobManager*/
            )
        {
            #region Configure Hangfire  
            //Basic Authentication added to access the Hangfire Dashboard  
            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                AppPath = null,
                DashboardTitle = "Hangfire Dashboard",
                /* Authorization = new[]{
                     new HangfireCustomBasicAuthenticationFilter{
                         User = configuration.GetSection("HangfireCredentials:UserName").Value,
                         Pass = configuration.GetSection("HangfireCredentials:Password").Value
                     }
                 },*/
                //Authorization = new[] { new DashboardNoAuthorizationFilter() },  
                //IgnoreAntiforgeryToken = true  
            });
            #endregion

            /*recurringJobManager.AddOrUpdate(
                "Run every minute",
                () => serviceProvider.GetService<IPrintJob>().Print(),
                "* * * * *"
                );*/

            return app;
        }
    }
}
