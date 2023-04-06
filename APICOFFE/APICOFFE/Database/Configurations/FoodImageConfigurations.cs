using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class FoodImageConfigurations : IEntityTypeConfiguration<FoodImage>
{
    public void Configure(EntityTypeBuilder<FoodImage> builder)
    {
        builder
            .ToTable("PlantImages");

        builder
            .HasOne(pi => pi.Food)
            .WithMany(p => p.FoodImages)
            .HasForeignKey(pi => pi.FoodId);
    }
}
