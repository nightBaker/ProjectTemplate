using Microsoft.EntityFrameworkCore;
using ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate;

namespace ProjectTemplate.PERSISTENCE
{
    public class SomeDbContext : DbContext
    {
        public SomeDbContext(DbContextOptions<SomeDbContext> options)
            : base(options)
        {

        }

        public DbSet<Some> Somes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
