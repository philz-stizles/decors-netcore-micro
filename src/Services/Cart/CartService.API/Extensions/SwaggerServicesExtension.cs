using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Cart.API.Extensions
{
    public static class SwaggerServicesExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo()
                    {
                        Title = "Cart API",
                        Version = "v1"
                    }
                );

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"bearer {token}\""
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                        // new string[] {}

                    }
                });

                options.CustomSchemaIds(type => type.ToString());

                // c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                // {
                //   { "Bearer", new string[] { } }
                // });

                // var xmlCommentsFile = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";
                // var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                // setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "Cart API v1"
                );

                options.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root 
                // @(http://localhost:<port>/), set the RoutePrefix property to an empty string:
            });

            return app;
        }
    }
}
