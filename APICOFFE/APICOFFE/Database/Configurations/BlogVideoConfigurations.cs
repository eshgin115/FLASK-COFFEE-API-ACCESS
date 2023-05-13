using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class BlogVideoConfigurations : IEntityTypeConfiguration<BlogVideo>
{
    public void Configure(EntityTypeBuilder<BlogVideo> builder)
    {
        builder
        .ToTable("BlogVideos")
           .HasOne(bv => bv.Blog)
           .WithMany(b => b.BlogVideos)
           .HasForeignKey(bv => bv.BlogId);
    }
}