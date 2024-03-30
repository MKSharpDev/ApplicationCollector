using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCollector.Infrastructure.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<Speaker> Authors { get; set; }
        public DbSet<ConfApplicationDraft> ConfApplicationDrafts { get; set; }
        public DbSet<ConfApplication> ConfApplications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfApplicationDraftConfiguration());
            modelBuilder.ApplyConfiguration(new ConfApplicationConfiguration());

            modelBuilder.ApplyConfiguration(new SpeakerConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
