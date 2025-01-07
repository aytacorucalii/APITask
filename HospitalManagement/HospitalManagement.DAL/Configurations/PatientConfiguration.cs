using HospitalManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagement.DAL.Configurations;

public class PatientConfiguration
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Surname).HasMaxLength(50);

            builder.HasOne(p => p.Insurance)
             .WithMany(c => c.Patients)
             .HasForeignKey(p => p.InsuranceId);
        }
    }
}
