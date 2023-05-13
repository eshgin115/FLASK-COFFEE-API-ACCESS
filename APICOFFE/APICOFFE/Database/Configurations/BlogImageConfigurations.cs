using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class BlogImageConfigurations : IEntityTypeConfiguration<BlogImage>
{
    public void Configure(EntityTypeBuilder<BlogImage> builder)
    {
        builder
        .ToTable("BlogImages")
           .HasOne(bi => bi.Blog)
           .WithMany(b => b.BlogImages)
           .HasForeignKey(bi => bi.BlogId);
    }
}