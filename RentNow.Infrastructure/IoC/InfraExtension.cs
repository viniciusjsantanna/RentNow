using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentNow.Application.Interfaces;
using RentNow.Infrastructure.Context;

namespace RentNow.Infrastructure.IoC
{
    public static class InfraExtension
    {
        public static IServiceCollection InfraRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("SqlConnection"));

            });
            services.AddTransient<IEFContext, EFContext>();
            return services;
        }
    }
}
