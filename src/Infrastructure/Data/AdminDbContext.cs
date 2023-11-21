using Application.Common.Interfaces;
using Domain.Entities.ResourceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AdminDbContext : DbContext, IAdminDbContext
    {
        public DbSet<Resource> Resources { get; set; }

        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
