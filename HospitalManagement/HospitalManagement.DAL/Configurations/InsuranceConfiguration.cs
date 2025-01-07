using HospitalManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagement.DAL.Configurations;
public class InsuranceConfiguration
{
    public class InsuranceConfig : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PersonInsurance).HasMaxLength(70);
        }
    }
}

