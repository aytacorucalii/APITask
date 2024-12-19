
using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.Core.Entities;

namespace EmployeePr.BL.Services.Abstractions;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllAsync();
    Task<Department> GetByIdAsync(int id);
    Task CreateAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(int id);
}
