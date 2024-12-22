using EmployeePr.Core.Entities.Base;
namespace employeePr.DAL.Repositories.Abstractions;

public interface IGenericRepository<Tentity> where Tentity : BaseEntity, new()
{
    Task<IEnumerable<Tentity>> GetAllAsync();
    Task<Tentity> GetByIdAsync(int id);
    Task CreateAsync(Tentity entity);
    Task UpdateAsync(Tentity entity);
    Task DeleteAsync(int id);
    Task<int>SaveChangesAsync();    
}
