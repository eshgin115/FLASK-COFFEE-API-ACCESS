using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class ShortInfoConfigurations : IEntityTypeConfiguration<ShortInfo>
{
    private int _idCounter = 1;
    public void Configure(EntityTypeBuilder<ShortInfo> builder)
    {
        builder
            .ToTable("ShortInfo");


        builder
            .HasData(
                new ShortInfo
                {
                    Id = _idCounter++,
                    PhoneNumber = "000 (123) 456 7890",
                    PlaceInfo = "A small river named Duden flows by their place and supplies.",
                    ShortеTitleStreet = "198 West 21th Street",
                    TitleStreet = "203 Fake St. Mountain View, San Francisco, California, USA",
                    WorkingHoursByDay = "Open Monday-Friday",
                    HoursOfWork = "8:00am - 9:00pm"
                }
            );
    }
}