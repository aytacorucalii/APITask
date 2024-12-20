using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorksShop.Core.Entities;

namespace WorksShop.DAL.DAL.Configurations;

public class WorkShopConfiguration : IEntityTypeConfiguration<Workshop>
{
    public void Configure(EntityTypeBuilder<Workshop> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title)
               .IsRequired()
               .HasMaxLength(150);
    }
}
