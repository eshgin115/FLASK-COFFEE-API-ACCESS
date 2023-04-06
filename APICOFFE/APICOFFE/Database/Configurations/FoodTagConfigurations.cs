using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class FoodTagConfigurations : IEntityTypeConfiguration<FoodTag>
{
    public void Configure(EntityTypeBuilder<FoodTag> builder)
    {
        builder
            .ToTable("FoodTags");


        builder
            .HasKey(pt => new { pt.FoodId, pt.TagId });

        builder
           .HasOne(pt => pt.Food)
           .WithMany(p => p.FoodTags)
           .HasForeignKey(pt => pt.FoodId);

        builder
            .HasOne(pt => pt.Tag)
            .WithMany(t => t.FoodTags)
            .HasForeignKey(pt => pt.TagId);
    }
}
