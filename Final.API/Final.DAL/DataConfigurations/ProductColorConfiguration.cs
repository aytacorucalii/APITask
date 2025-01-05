using Final.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final.DAL.DataConfigurations;

public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
{
    public void Configure(EntityTypeBuilder<ProductColor> builder)
    {
        builder.HasKey(x => new {x.ProductId,x.ColorId});
        builder.HasOne(p => p.Product)
               .WithMany(p => p.ProductColors)
               .HasForeignKey(p => p.ProductId);

        builder.HasOne(c => c.Color)
               .WithMany(c => c.ProductColors)
               .HasForeignKey(c => c.ColorId);
    }
}

