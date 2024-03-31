using ApplicationCollector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationCollector.Infrastructure.Core.Configurations
{
    //public class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
    //{
    //    public void Configure(EntityTypeBuilder<Speaker> builder)
    //    {
    //        builder.HasKey(s => s.Id);

    //        builder
    //            .HasOne(s => s.ApplicationDraft)
    //            .WithOne(a => a.Speaker)
    //            .HasForeignKey<Speaker>(s => s.ApplicationDraftId);

    //        builder
    //            .HasMany(s => s.Applications)
    //            .WithOne(a => a.Speaker);
    //    }
    //}
}
