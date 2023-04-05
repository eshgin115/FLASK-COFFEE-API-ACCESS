using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class DrinkTagConfigurations : IEntityTypeConfiguration<DrinkTag>
{
    public void Configure(EntityTypeBuilder<DrinkTag> builder)
    {
        builder
            .ToTable("DrinkTags");


        builder
            .HasKey(pt => new { pt.DrinkId, pt.TagId });

        builder
           .HasOne(pt => pt.Drink)
           .WithMany(p => p.DrinkTags)
           .HasForeignKey(pt => pt.DrinkId);

        builder
            .HasOne(pt => pt.Tag)
            .WithMany(t => t.DrinkTags)
            .HasForeignKey(pt => pt.TagId);
    }
}