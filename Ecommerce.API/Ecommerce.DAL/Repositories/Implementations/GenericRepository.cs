using Ecommerce.DAL.DAL;
using Ecommerce.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL.Repositories.Implementations;

public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : class, new()
{
    private readonly AppDbContext _appDbContext;
    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    DbSet<Tentity> Table => _appDbContext.Set<Tentity>();
    public async Task CreateAsync(Tentity entity)
    {
        await Table.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<Tentity>> GetAllAsync()
    {
       return await Table.ToListAsync();
    }
    public async Task<Tentity> GetByIdAsync(int id)
    {
        return await Table.FindAsync(id);
    }

    public async Task Update(Tentity entity)
    {
        Table.Update(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var value = await Table.FindAsync(id);
        if (value != null) 
        {
            Table.Remove(value);
            await _appDbContext.SaveChangesAsync();
        }

    }
    public async Task<int> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }

}
