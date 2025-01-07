using HospitalManagement.BL.DTOs.PatientDTOs;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.Services.Abstractions;

public interface IPatientService
{
    Task<ICollection<Patient>> GetAllAsync();
    Task<Patient> CreateAsync(PatientCreateDTO createDto);
    Task<Patient> GetByIdAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> UpdateAsync(int id, PatientCreateDTO entityDto);
    Task<bool> EditAsync(int id, PatientCreateDTO entityDto);
   
}
