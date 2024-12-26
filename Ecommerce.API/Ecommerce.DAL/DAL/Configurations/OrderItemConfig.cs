using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.DAL.DAL.Configurations;

public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(e => e.Id);
        builder
            .HasOne(e => e.Order)
            .WithMany(o=>o.OrderItems)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
           .HasOne(e => e.Product)
           .WithMany(o => o.OrderItems)
           .HasForeignKey(o => o.ProductId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
