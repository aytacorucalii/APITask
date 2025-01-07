using HospitalManagement.BL.DTOs.InsuranceDTOs;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.Services.Abstractions;

public interface IInsureService 
{
    Task<ICollection<Insurance>> GetAllAsync();
    Task<Insurance> CreateAsync(InsuranceCreateDTO createDto);
    Task<Insurance> GetByIdAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> UpdateAsync(int id, InsuranceCreateDTO entityDto);
    Task<bool> EditAsync(int id, InsuranceCreateDTO entityDto);
   
}
