using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class FeedbackConfigurations : IEntityTypeConfiguration<FeedBack>
{
    public void Configure(EntityTypeBuilder<FeedBack> builder)
    {
        builder
            .ToTable("FeedBacks");
        builder
           .HasOne(f => f.Role)
           .WithMany(r => r.FeedBacks)
           .HasForeignKey(f => f.RoleId);
    }
}
