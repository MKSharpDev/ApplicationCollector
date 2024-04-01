using ApplicationCollector.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCollector.Infrastructure.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<Speaker> Authors { get; set; }
        public DbSet<ConfApplication> ConfApplications { get; set; }
        public DbSet<ConfApplicationDraft> ConfApplicationDrafts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
