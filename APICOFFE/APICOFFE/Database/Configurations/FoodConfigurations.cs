using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class FoodConfigurations : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder
            .ToTable("Foods");
        builder
        .HasOne(bp => bp.FoodCategory)
        .WithMany(basket => basket.Foods)
        .HasForeignKey(bp => bp.FoodCategoryId);

    }
}