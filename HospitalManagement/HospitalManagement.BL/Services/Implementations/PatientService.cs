using AutoMapper;
using HospitalManagement.BL.DTOs.PatientDTOs;
using HospitalManagement.BL.Exceptions;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.Core.Entities;
using HospitalManagement.DAL.Repositories.Abstractions;

namespace HospitalManagement.BL.Services.Implementations;

public class PatientService : IPatientService
{ 
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<Patient>> GetAllAsync()
    {
       return await _patientRepository.GetAllAsync();
    }
    public async Task<Patient> CreateAsync(PatientCreateDTO createDto)
    {
        Patient createdPatient = _mapper.Map<Patient>(createDto);
        createdPatient.CreatedAt = DateTime.UtcNow.AddHours(4);
        var createdEntity = await _patientRepository.CreateAsync(createdPatient);
        await _patientRepository.SaveChangesAsync();
        return createdEntity;
    }


    public async Task<Patient> GetByIdAsync(int id)
    {
        if (!await _patientRepository.IsExistsAsync(id))
        {
            throw new EntityNotFoundException();
        }
        return await _patientRepository.GetByIdAsync(id);
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var Entity = await GetByIdAsync(id);
       _patientRepository.SoftDelete(Entity);
        await _patientRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, PatientCreateDTO entityDto)
    {
        var Entity = await GetByIdAsync(id);
        Patient updated =_mapper.Map<Patient>(entityDto);
        updated.CreatedAt = DateTime.UtcNow.AddHours(4);
        updated.Id = id;
        _patientRepository.Update(updated);
        await _patientRepository.SaveChangesAsync();
        return true;
    }
    public async  Task<bool> EditAsync(int id, PatientCreateDTO entityDto)
    {
        var Entity = await GetByIdAsync(id);
        _mapper.Map(entityDto, Entity);

        Entity.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _patientRepository.Update(Entity);
        await _patientRepository.SaveChangesAsync();
        return true;
    }

}
