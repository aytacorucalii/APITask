using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WorksShop.Core.Entities;

namespace WorksShop.DAL.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Workshop> WorkShops { get; set; }
    public DbSet<Participant> Participants { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
