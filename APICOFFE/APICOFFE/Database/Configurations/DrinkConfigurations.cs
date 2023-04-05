using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class DrinkConfigurations : IEntityTypeConfiguration<Drink>
{
    public void Configure(EntityTypeBuilder<Drink> builder)
    {
        builder
            .ToTable("Drinks");
        builder
        .HasOne(bp => bp.DrinkCategory)
        .WithMany(basket => basket.Drinks)
        .HasForeignKey(bp => bp.DrinkCategoryId);

    }
}