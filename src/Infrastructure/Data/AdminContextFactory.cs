using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AdminContextFactory : IDesignTimeDbContextFactory<AdminDbContext>
    {
        public  AdminDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdminDbContext>();
            optionsBuilder.UseSqlServer("Server=SQLDB02\\MANOLITO;Database=sm_admin;Integrated Security=True;TrustServerCertificate=True",
                builderOptions =>
                    builderOptions.MigrationsAssembly(typeof(AdminDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new AdminDbContext(optionsBuilder.Options);
        }
    }
}
