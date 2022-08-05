using Microsoft.EntityFrameworkCore;
using ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate;

namespace ProjectTemplate.PERSISTENCE
{
    public class ProjectTemplateDbContext : DbContext
    {
        public ProjectTemplateDbContext(DbContextOptions<ProjectTemplateDbContext> options)
            : base(options)
        {

        }

        public DbSet<Some> Somes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
