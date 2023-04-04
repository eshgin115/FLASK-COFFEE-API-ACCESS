using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class SizeConfigurations : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder
          .ToTable("Sizes");

    }
}
