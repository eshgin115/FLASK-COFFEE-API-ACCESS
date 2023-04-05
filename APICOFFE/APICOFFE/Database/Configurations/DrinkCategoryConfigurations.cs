using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class DrinkCategoryConfigurations : IEntityTypeConfiguration<DrinkCategory>
{
    public void Configure(EntityTypeBuilder<DrinkCategory> builder)
    {
        builder
            .ToTable("DrinkCategories");
    }
}