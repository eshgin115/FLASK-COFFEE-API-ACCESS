using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class PlantSizeConfigurations : IEntityTypeConfiguration<FoodSize>
{
    public void Configure(EntityTypeBuilder<FoodSize> builder)
    {
        builder
            .ToTable("FoodSizes");


        builder
            .HasKey(ps => new { ps.FoodId, ps.SizeId });

        builder
           .HasOne(pc => pc.Food)
           .WithMany(p => p.FoodSizes)
           .HasForeignKey(pc => pc.FoodId);

        builder
            .HasOne(pc => pc.Size)
            .WithMany(c => c.FoodSizes)
            .HasForeignKey(pc => pc.SizeId);
    }
}
