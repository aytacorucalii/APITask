using AutoMapper;
using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.BL.DTOs.DepartmentDTOs;
using EmployeePr.BL.Services.Abstractions;
using EmployeePr.Core.Entities;

namespace EmployeePr.BL.Services.Implementations;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _departmentRepository.GetAllAsync();
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        return await _departmentRepository.GetByIdAsync(id);
    }

    public async Task<Department> CreateAsync(CreateDepartmentDTO departmentDto)
    {
        Department department = _mapper.Map<Department>(departmentDto);

        await _departmentRepository.CreateAsync(department);
        await _departmentRepository.SaveChangesAsync();
        return department;
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
