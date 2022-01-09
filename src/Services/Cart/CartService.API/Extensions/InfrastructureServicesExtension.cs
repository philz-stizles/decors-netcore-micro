﻿using Cart.Application.Contracts.Repositories;
using Cart.Application.Contracts.Services;
using Cart.Infrastructure.Persistence.Caching;
using Cart.Infrastructure.Persistence.Context;
using Cart.Infrastructure.Persistence.Repositories;
using Cart.Infrastructure.Services.Client;
using Cart.Infrastructure.Services.MessageQueue;
using Cart.Infrastructure.Services.Notifications;
using Cart.Infrastructure.Services.Payment;
using Cart.Infrastructure.Services.Security;
using Cart.Infrastructure.Services.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Net;
using System.Net.Http;

namespace Cart.Infrastructure
{
    public static class InfrastructureServicesExtension
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, 
            IConfiguration configuration
        )
        {
            // Database injection.
            services.AddDbContext<DataDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppConnectionString")));

            // Redis injection.
            services.AddSingleton<IConnectionMultiplexer>(c => {
                var config = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(config);
            });

            // Http client
            services.AddHttpClient("clientName", client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("ClientSettings:Uri").Value);
                client.Timeout = new TimeSpan(0, 0, 30);
                client.DefaultRequestHeaders.Clear();
            })
            .ConfigurePrimaryHttpMessageHandler(handler =>
              new HttpClientHandler()
              {
                  AutomaticDecompression = DecompressionMethods.GZip
              }
            );

            // Repository injections.
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICouponRepository,CouponRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuditRepository, AuditRepository>();
            services.AddScoped<ICartService, CartRepository>();
            services.AddScoped<IDeliveryMethodRepository, DeliveryMethodRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            // Service injections.
            services.AddScoped<IJwtService, JWTService>();
            services.AddScoped<IAWSSESService, AWSSESService>();
            services.AddScoped<IAWSSNSService, AWSSNSService>();
            services.AddScoped<IAWSSQSService, AWSSQSService>();
            services.AddScoped<IAWSS3Service, AWSS3Service>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();

            return services;
        }
    }
}
