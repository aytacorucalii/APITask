using Final.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Final.DAL.DataConfigurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {

        builder.Property(x => x.FirstName).HasMaxLength(30);
        builder.Property(x => x.LastName).HasMaxLength(50);

    }
}