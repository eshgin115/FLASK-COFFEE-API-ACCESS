using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class DrinkSizeConfigurations : IEntityTypeConfiguration<DrinkSize>
{
    public void Configure(EntityTypeBuilder<DrinkSize> builder)
    {
        builder
            .ToTable("DrinkSizes");

        builder
            .HasKey(ps => new { ps.DrinkId, ps.SizeId });

        builder
           .HasOne(pc => pc.Drink)
           .WithMany(p => p.DrinkSizes)
           .HasForeignKey(pc => pc.DrinkId);

        builder
            .HasOne(pc => pc.Size)
            .WithMany(c => c.DrinkSizes)
            .HasForeignKey(pc => pc.SizeId);
    }
}