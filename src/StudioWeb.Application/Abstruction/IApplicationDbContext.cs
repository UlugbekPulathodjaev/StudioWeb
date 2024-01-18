using Microsoft.EntityFrameworkCore;
using StudioWeb.Domain.Entities;

namespace StudioWeb.Application.Abstruction
{
    public interface IApplicationDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
