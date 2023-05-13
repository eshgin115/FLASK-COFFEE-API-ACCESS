using APICOFFE.Database.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class DiscoverMenuConfigurations : IEntityTypeConfiguration<DiscoverMenu>
{
    private int _idCounter = 1;
    public void Configure(EntityTypeBuilder<DiscoverMenu> builder)
    {
        builder
            .ToTable("DiscoverMenu");

        builder
            .HasData(
                new DiscoverMenu
                {
                    Id = _idCounter++,
                    Title = "Discover OUR MENU",
                    Content = "Far far away, behind the word mountains",
                    FirstHrefName = "View Full Menu",
                    FirstHrefURL = "#"
                }
            );

    }
}
