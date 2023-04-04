using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;
public class WelcomeSliderConfigurations : IEntityTypeConfiguration<WelcomeSlider>
{
    public void Configure(EntityTypeBuilder<WelcomeSlider> builder)
    {
        builder
          .ToTable("WelcomeSliders");
    }
}