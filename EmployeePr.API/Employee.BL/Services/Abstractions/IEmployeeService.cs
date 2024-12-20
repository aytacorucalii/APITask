

using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.BL.DTOs.EmployeeDTOs;
using EmployeePr.Core.Entities;

namespace EmployeePr.BL.Services.Abstractions;

public interface IEmployeeService 
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee> GetByIdAsync(int id);
    Task<Employee> CreateAsync(CreateEmployeeDTO createEmployee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(int id);
}
