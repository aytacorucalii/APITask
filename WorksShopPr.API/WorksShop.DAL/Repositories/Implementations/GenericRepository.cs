using Microsoft.EntityFrameworkCore;
using WorksShop.Core.Entities.Base;
using WorksShop.DAL.DAL;
using WorksShop.DAL.Repositories.Abstractions;

namespace WorksShop.DAL.Repositories.Implementations;

public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
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


    public async Task UpdateAsync(Tentity entity)
    {
        Table.Update(entity);
        await _appDbContext.SaveChangesAsync();
    }


    public async Task DeleteAsync(int id)
    {  
        var entity= await Table.FindAsync(id);
        if (entity != null) 
        { 
            Table.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }
       
    }

    public async Task<int> SaveChangesAsync()
    {
      return await _appDbContext.SaveChangesAsync();
    }

}
