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
                // we can get an option to use another type of database here
                // sometime in the near future
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
