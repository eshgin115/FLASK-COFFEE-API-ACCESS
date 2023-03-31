using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class DiscoverMenuImageConfigurations : IEntityTypeConfiguration<DiscoverMenuImage>
{
    public void Configure(EntityTypeBuilder<DiscoverMenuImage> builder)
    {
        builder
            .ToTable("DiscoverMenuImages");

        builder
            .HasOne(pi => pi.DiscoverMenu)
            .WithMany(p => p.DiscoverMenuImages)
            .HasForeignKey(pi => pi.DiscoverMenuId);
    }
}
