using EmailSenderApp.Application.AuthService;

//IserviceCollection ishlashi uchun vvv
using EmailSenderApp.Application.Services;
//AddScoped ishlashi uchun vvv
using Microsoft.Extensions.DependencyInjection;

namespace EmailSenderApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ISendEmailService, SendEmailService>();
            services.AddScoped<IAuthServise, AuthServise>();
            return services;
        }
    }
}
