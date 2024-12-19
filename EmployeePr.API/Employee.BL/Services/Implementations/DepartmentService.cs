

using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.BL.Services.Abstractions;
using EmployeePr.Core.Entities;

namespace EmployeePr.BL.Services.Implementations;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository  departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _departmentRepository.GetAllAsync();
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        return await _departmentRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Department department)
    {
        await _departmentRepository.CreateAsync(department);
    }

    public async Task UpdateAsync(Department department)
    {
        await _departmentRepository.UpdateAsync(department);
    }

    public async Task DeleteAsync(int id)
    {
        await _departmentRepository.DeleteAsync(id);
    }
}
