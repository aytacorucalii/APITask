using EmployeePr.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace employeePr.DAL.DAL.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {

        builder.Property(a => a.FirstName).HasMaxLength(30);
        builder.Property(a => a.LastName).HasMaxLength(50);

    }
}
