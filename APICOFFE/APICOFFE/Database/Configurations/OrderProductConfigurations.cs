using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations;

public class OrderProductConfigurations : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        builder
            .ToTable("OrderProducts");

        builder
          .HasOne(bp => bp.Order)
          .WithMany(basket => basket.OrderProducts)
          .HasForeignKey(bp => bp.OrderId);

        builder
          .HasOne(bp => bp.Food)
          .WithMany(plant => plant.OrderProducts)
          .HasForeignKey(bp => bp.FoodId);

    }
}
