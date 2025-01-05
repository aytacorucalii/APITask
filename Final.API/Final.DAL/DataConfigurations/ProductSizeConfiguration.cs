using Final.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final.DAL.DataConfigurations;

public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
{
    public void Configure(EntityTypeBuilder<ProductSize> builder)
    {
        builder.HasKey(x => new { x.ProductId, x.SizeId });
        builder.HasOne(p => p.Product)
               .WithMany(p => p.ProductSizes)
               .HasForeignKey(p => p.ProductId);

        builder.HasOne(c => c.Size)
               .WithMany(c => c.ProductSizes)
               .HasForeignKey(c => c.SizeId);
    }
}
