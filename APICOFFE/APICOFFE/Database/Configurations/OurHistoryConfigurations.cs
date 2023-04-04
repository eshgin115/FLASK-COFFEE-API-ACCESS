using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class OurHistoryConfigurations : IEntityTypeConfiguration<OurHistory>
{
    private int _idCounter = 1;
    public void Configure(EntityTypeBuilder<OurHistory> builder)
    {
        builder
            .ToTable("OurHistory");


        builder
            .HasData(
                new OurHistory
                {
                    Id = _idCounter++,
                    Subheading = "Discover",
                    Title = "OUR STORY",
                    Content = "",
                }
            );
    }
}