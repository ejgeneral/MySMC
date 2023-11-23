using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Interceptors;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = Environment.GetEnvironmentVariable("SM_ADMIN");

            Guard.Against.NullOrEmpty(connectionString, message: "Connection String 'AdminConnection' not found!");
            services.AddScoped<AuditableEntitySaveChangesInterceptor>(); 
            services.AddScoped<IDateTime, DateTimeService>();
            
            services.AddDbContext<AdminDbContext>((sp, options) =>
            {
                // we can get an option to use another type of database here
                // sometime in the near future
                options.UseSqlServer(connectionString);
            });
            
            services.AddScoped<IAdminDbContext>(provider => provider.GetRequiredService<AdminDbContext>());

            return services;
        }
    }
}
