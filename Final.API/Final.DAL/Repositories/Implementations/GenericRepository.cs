using Final.Core.Entities.Base;
using Final.DAL.DAL;
using Final.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Final.DAL.Repositories.Implementations;

public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
{
    private readonly AppDbContext _appDbContext;
    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    DbSet<Tentity>Entity => _appDbContext.Set<Tentity>();



    public async Task<ICollection<Tentity>> GetAllAsync()
    {
        return await Entity.Where(x => !x.IsDeleted).ToListAsync();
    }



    public async Task<Tentity> CreateAsync(Tentity entity)
    {
        await Entity.AddAsync(entity);
        return entity;
    }


    public async Task<Tentity> GetByIdAsync(int Id)
    {
        var entity = await Entity.FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
        _appDbContext.Entry(entity).State = EntityState.Detached;
        return entity;
    }


    public void Update(Tentity entity)
    {
        _appDbContext.Entry(entity).State = EntityState.Modified;

    }


    public void SoftDelete(Tentity entity)
    {
        entity.IsDeleted = true;
    }


    public async Task<int> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }


    public async Task<bool> IsExistsAsync(int Id)
    {
        return await Entity.AnyAsync(x => x.Id == Id && !x.IsDeleted);
    }
}
