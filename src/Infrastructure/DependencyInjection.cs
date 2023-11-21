using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("AdminConnection");

            Guard.Against.NullOrEmpty(connectionString, message: "Connection String 'AdminConnection' not found!");


            services.AddDbContext<AdminDbContext>((sp, options) =>
            {

            });

            return services;
        }
    }
}
