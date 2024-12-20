

using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.BL.DTOs.EmployeeDTOs;
using EmployeePr.BL.Services.Abstractions;
using EmployeePr.Core.Entities;

namespace EmployeePr.BL.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _employeeRepository.GetAllAsync();
    }
    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _employeeRepository.GetByIdAsync(id);
    }

    public async Task<Employee> CreateAsync(CreateEmployeeDTO createEmployee)
    {
        Employee employee = new Employee
        {
            Name = createEmployee.Name,
            SurName = createEmployee.SurName,
            DepartmentId = createEmployee.DepartmentId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            DeletedAt = DateTime.Now
        };

        await _employeeRepository.CreateAsync(employee);

        await _employeeRepository.SaveChangesAsync();// error var
        return employee;
    }

    public async Task UpdateAsync(Employee employee)
    {
        await _employeeRepository.UpdateAsync(employee);
    }

    public async Task DeleteAsync(int id)
    {
        await _employeeRepository.DeleteAsync(id);
    }

}

   

