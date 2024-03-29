using Microsoft.EntityFrameworkCore;
using ApplicationCollector.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ApplicationCollector.Infrastructure.Core.Configurations
{
    public class ConfApplicationConfiguration : IEntityTypeConfiguration<ConfApplication>
    {
        public void Configure(EntityTypeBuilder<ConfApplication> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .HasOne(a => a.Speaker)
                .WithOne(s => s.Application)
                .HasForeignKey<ConfApplication>(a => a.Author);
        }
    }
}
