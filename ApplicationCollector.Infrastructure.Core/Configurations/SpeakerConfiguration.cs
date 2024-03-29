using ApplicationCollector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationCollector.Infrastructure.Core.Configurations
{
    public class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
    {
        public void Configure(EntityTypeBuilder<Speaker> builder)
        {
            builder.HasKey(s => s.Author);

            builder
                .HasOne(s => s.Application)
                .WithOne(a => a.Speaker)
                .HasForeignKey<Speaker>(a => a.ApplicationId);
        }
    }
}
