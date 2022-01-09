using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace AuthService.API.Extensions
{
    public static class AuthServicesExtension
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, 
            IConfiguration Configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    // ValidateLifetime = false,
                    // ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(Configuration.GetSection("JwtSettings:SecretKey").Value)
                    ),
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = Configuration["JwtSettings:Issuer"],
                    ValidAudience = Configuration["JwtSettings:Issuer"],
                };
            });
            //.AddMicrosoftAccount(options => {
            //    options.ClientId = Configuration["Authentication:Microsoft:ClientId"];
            //    options.ClientSecret =Configuration["Authentication:Microsoft:ClientSecret"];
            //})
            //.AddGoogle(options => {
            //    IConfigurationSection googleAuthSection = Configuration.GetSection("Authentication:Google");
            //    options.ClientId = googleAuthSection["ClientId"];
            //    options.ClientSecret = googleAuthSection["ClientSecret"];
            //})
            //.AddTwitter(options => {
            //    options.ConsumerKey = Configuration["Authentication:Twitter:ConsumerAPIKey"];
            //    options.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
            //    options.RetrieveUserDetails = true;
            //})
            //.AddFacebook(options => {
            //    options.AppId = Configuration["Authentication:Facebook:AppId"];
            //    options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            //});

            services.AddAuthorization(options => {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireClaim("Admin"));
                options.AddPolicy("RequireMemberRole", policy => policy.RequireRole("Member"));
            });

            return services;
        }

        public static IApplicationBuilder UseAuthServices(this IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseAuthorization();

            return app;
        }

    }
}
