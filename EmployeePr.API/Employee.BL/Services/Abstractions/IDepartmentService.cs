
using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.BL.DTOs.DepartmentDTOs;
using EmployeePr.Core.Entities;

namespace EmployeePr.BL.Services.Abstractions;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllAsync();
    Task<Department> GetByIdAsync(int id);
    Task<Department> CreateAsync(CreateDepartmentDTO department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(int id);
}
