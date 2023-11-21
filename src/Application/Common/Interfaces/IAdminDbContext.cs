using Domain.Entities.ResourceAggregate;

namespace Application.Common.Interfaces
{
    public interface IAdminDbContext
    {
        DbSet<Resource> Resources { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
