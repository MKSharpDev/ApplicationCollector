using ApplicationCollector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationCollector.Infrastructure.Core.Configurations
{
    public class ConfActivityConfiguration : IEntityTypeConfiguration<ConfActivity>
    {
        public void Configure(EntityTypeBuilder<ConfActivity> builder)
        {
            builder.HasKey(c => c.Id);


            builder
                .HasMany(c => c.Speakers)
                .WithOne(s => s.Activity)
                .HasForeignKey(s => s.ActivityId);
        }
    }
}
