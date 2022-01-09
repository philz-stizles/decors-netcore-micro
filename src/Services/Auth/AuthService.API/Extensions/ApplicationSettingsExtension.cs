using Decors.Application.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.API.Extensions
{
    public static class ApplicationSettingsExtension
    {
        public static IServiceCollection AddApplicationSettings(this IServiceCollection services,
            IConfiguration Configuration)
        {
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.Configure<SendGridSettings>(Configuration.GetSection("SendGridSettings"));
            services.Configure<MailgunSettings>(Configuration.GetSection("MailgunSettings"));
            services.Configure<FileSettings>(Configuration.GetSection("FileSettings"));
            services.Configure<AWSS3Settings>(Configuration.GetSection("AWSS3Settings"));
            services.Configure<AWSSESSettings>(Configuration.GetSection("AWSSESSettings"));
            services.Configure<AWSSNSSettings>(Configuration.GetSection("AWSSNSSettings"));
            services.Configure<AWSSQSSettings>(Configuration.GetSection("AWSSQSSettings"));
            services.Configure<StripeSettings>(Configuration.GetSection("StripeSettings"));
            services.Configure<TwilioSettings>(Configuration.GetSection("TwilioSettings"));

            return services;
        }
    }
}
