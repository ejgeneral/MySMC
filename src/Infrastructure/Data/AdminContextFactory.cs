using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Infrastructure.Data
{
    public class AdminContextFactory : IDesignTimeDbContextFactory<AdminDbContext>
    {
        public  AdminDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdminDbContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SM_ADMIN"),
                builderOptions =>
                    builderOptions.MigrationsAssembly(typeof(AdminDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new AdminDbContext(optionsBuilder.Options);
        }
    }
}
