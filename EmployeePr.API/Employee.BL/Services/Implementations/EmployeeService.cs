

using AutoMapper;
using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.BL.DTOs.EmployeeDTOs;
using EmployeePr.BL.Services.Abstractions;
using EmployeePr.Core.Entities;

namespace EmployeePr.BL.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
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


        Employee employee = _mapper.Map<Employee>(createEmployee);
        employee.CreatedAt = DateTime.UtcNow.AddHours(4);
        await _employeeRepository.CreateAsync(employee);
        await _employeeRepository.SaveChangesAsync();
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

   

