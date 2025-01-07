using AutoMapper;
using HospitalManagement.BL.DTOs.InsuranceDTOs;
using HospitalManagement.BL.Exceptions;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.Core.Entities;
using HospitalManagement.DAL.Repositories.Abstractions;

namespace HospitalManagement.BL.Services.Implementations;

public class InsureService : IInsureService
{
    private readonly IInsuranceRepository _insuranceRepository;
    private readonly IMapper _mapper;
    public InsureService(IInsuranceRepository insuranceRepository, IMapper mapper)
    {
        _insuranceRepository = insuranceRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<Insurance>> GetAllAsync()
    {
        return await _insuranceRepository.GetAllAsync();
    }
    public async Task<Insurance> CreateAsync(InsuranceCreateDTO createDto)
    {
        Insurance createdInsurance = _mapper.Map<Insurance>(createDto);
        createdInsurance.CreatedAt = DateTime.UtcNow.AddHours(4);
        var Entity = await _insuranceRepository.CreateAsync(createdInsurance);
        await _insuranceRepository.SaveChangesAsync();
        return Entity;
    }


    public async Task<Insurance> GetByIdAsync(int id)
    {
        if (!await _insuranceRepository.IsExistsAsync(id))
        {
            throw new EntityNotFoundException();
        }
        return await _insuranceRepository.GetByIdAsync(id);
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var Entity = await GetByIdAsync(id);
        _insuranceRepository.SoftDelete(Entity);
        await _insuranceRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, InsuranceCreateDTO entityDto)
    {
        var Entity = await GetByIdAsync(id);
        Insurance updated = _mapper.Map<Insurance>(entityDto);
        updated.CreatedAt = DateTime.UtcNow.AddHours(4);
        updated.Id = id;
        _insuranceRepository.Update(updated);
        await _insuranceRepository.SaveChangesAsync();
        return true;
    }
    public async Task<bool> EditAsync(int id, InsuranceCreateDTO entityDto)
    {
        var Entity = await GetByIdAsync(id);
        _mapper.Map(entityDto, Entity);

        Entity.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _insuranceRepository.Update(Entity);
        await _insuranceRepository.SaveChangesAsync();
        return true;
    }
}
