using System.Reflection;
using HospitalManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DAL.DAL;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions) { }
 
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Insurance>Insurances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
