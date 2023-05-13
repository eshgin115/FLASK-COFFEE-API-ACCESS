using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class BlogConfigurations : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        //builder
        //.ToTable("Blogs")
        //   .HasOne(b => b.User)
        //   .WithMany(u => u.Blogs)
        //   .HasForeignKey(b => b.UserId);

        //builder
        //    .HasOne(b => b.BlogCategory)
        //   .WithMany(c => c.Blogs)
        //   .HasForeignKey(b => b.BlogCategoryId);
    }
}