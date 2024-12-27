namespace Ecommerce.DAL.Repositories.Abstractions;

public interface IGenericRepository <Tentity> where Tentity : class , new()
{
    Task<IEnumerable<Tentity>> GetAllAsync();
    Task<Tentity> GetByIdAsync(int id);
    Task CreateAsync(Tentity entity);
    Task Update(Tentity entity);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
