using AutoMapper;
using Final.BL.DTOs.SizeDTOs;
using Final.BL.Exceptions.CommonExceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.DAL.Repositories.Abstractions;

namespace Final.BL.Services.Implementations;

public class SizeService : ISizeService
{
    private readonly ISizeRepository _sizeRepository;
    private readonly IMapper _mapper;
    public SizeService(IMapper mapper, ISizeRepository sizeRepository)
    {

        _mapper = mapper;
        _sizeRepository = sizeRepository;
    }

    public async Task<Size> CreateAsync(SizeCreateDTO createDto)
    {
        Size createdSize = _mapper.Map<Size>(createDto);
        var createdEntity = await _sizeRepository.CreateAsync(createdSize);
        await _sizeRepository.SaveChangesAsync();
        return createdEntity;
    }


    public async Task<ICollection<Size>> GetAllAsync()
    {
       return await _sizeRepository.GetAllAsync();
    }

    public async Task<Size> GetByIdAsync(int id)
    {
        if (!await _sizeRepository.IsExistsAsync(id))
        {
            throw new EntityNotFoundException();
        }
        return await _sizeRepository.GetByIdAsync(id);
    }
    public async Task<bool> EditAsync(int id, SizeCreateDTO editDTO)
    {
        var Entity = await GetByIdAsync(id);
        _mapper.Map(editDTO, Entity);
        _sizeRepository.Update(Entity);
        await _sizeRepository.SaveChangesAsync();
        return true;
    }
}
