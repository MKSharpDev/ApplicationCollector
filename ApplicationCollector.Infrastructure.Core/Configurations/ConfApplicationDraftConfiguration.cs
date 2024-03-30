using Microsoft.EntityFrameworkCore;
using ApplicationCollector.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ApplicationCollector.Infrastructure.Core.Configurations
{
    public class ConfApplicationDraftConfiguration : IEntityTypeConfiguration<ConfApplicationDraft>
    {
        public void Configure(EntityTypeBuilder<ConfApplicationDraft> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .HasOne(a => a.Speaker)
                .WithOne(s => s.ApplicationDraft)
                .HasForeignKey<ConfApplicationDraft>(a => a.Author);
        }
    }
}
