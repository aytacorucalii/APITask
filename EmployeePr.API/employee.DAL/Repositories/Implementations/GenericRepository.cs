using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.Core.Entities.Base;
using EmployeePr.DAL.DAL;
using Microsoft.EntityFrameworkCore;
namespace employeePr.DAL.Repositories.Implementations;

public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
{
    private readonly AppDbContext _appDbContext;
    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
        DbSet<Tentity> EntityTable=> _appDbContext.Set<Tentity>();


    public async Task CreateAsync(Tentity entity)
    {
        await EntityTable.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<Tentity>> GetAllAsync()
    {
        return await EntityTable.ToListAsync();
    }

    public async Task<Tentity> GetByIdAsync(int id)
    {
        return await EntityTable.FindAsync(id);
    }
    public async Task UpdateAsync(Tentity entity)
    {
        EntityTable.Update(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await EntityTable.FindAsync(id);
        if (entity != null)
        {
            EntityTable.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task<int> SaveChangesAsync()
    {
       return await _appDbContext.SaveChangesAsync();
    }
}
