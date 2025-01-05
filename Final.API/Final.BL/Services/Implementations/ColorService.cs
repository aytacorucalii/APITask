using AutoMapper;
using Final.BL.DTOs.ColorDTOs;
using Final.BL.Exceptions.CommonExceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.DAL.Repositories.Abstractions;

namespace Final.BL.Services.Implementations;

public class ColorService : IColorService
{
   private readonly IColorRepository _colorRepository;
    private readonly IMapper _mapper;
    public ColorService(IMapper mapper, IColorRepository colorRepository)
    {

        _mapper = mapper;
        _colorRepository = colorRepository;
    }

    public async Task<Color> CreateAsync(ColorCreateDTO createDto)
    {
        Color createdColor = _mapper.Map<Color>(createDto);
        var createdEntity = await _colorRepository.CreateAsync(createdColor);
        await _colorRepository.SaveChangesAsync();
        return createdEntity;
    }

    public async Task<ICollection<Color>> GetAllAsync()
    {
       return await _colorRepository.GetAllAsync();
    }

    public async Task<Color> GetByIdAsync(int id)
    {
        if (!await _colorRepository.IsExistsAsync(id))
        {
            throw new EntityNotFoundException();
        }
        return await _colorRepository.GetByIdAsync(id);
    }
}
