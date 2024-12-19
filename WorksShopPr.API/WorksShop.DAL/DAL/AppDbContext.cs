using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WorksShop.Core.Entities;

namespace WorksShop.DAL.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<WorkShop> workShops { get; set; }
    public DbSet<Participant> participants { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
