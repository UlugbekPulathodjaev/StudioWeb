using Microsoft.EntityFrameworkCore;
using StudioWeb.Application.Abstruction;
using StudioWeb.Domain.Entities;

namespace StudioWeb.Infrastructure.Data
{
    public class BotDbContext : DbContext, IApplicationDbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options)
            => Database.Migrate();

        public DbSet<Customer> Customers { get; set; }

        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
            => await base.SaveChangesAsync(cancellationToken);

    }
}
