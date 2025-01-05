using AutoMapper;
using Final.BL.DTOs.ProductColorDTOs;
using Final.BL.Exceptions.CommonExceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.DAL.Repositories.Abstractions;
using Final.DAL.Repositories.Implementations;

namespace Final.BL.Services.Implementations;

public class ProductColorService : IProductColorService
{
    private readonly IGenericRepository<ProductColor> _genericRepository;
    private readonly IMapper _mapper;

    public ProductColorService(IGenericRepository<ProductColor> genericRepository, IMapper mapper)
    {
        _genericRepository = genericRepository;
        _mapper = mapper;
    }

    public async Task<ProductColor> CreateAsync(ProductColorCreateDTO createDto)
    {
        ProductColor createdProduct = _mapper.Map<ProductColor>(createDto);
        var createdEntity = await _genericRepository.CreateAsync(createdProduct);
        await _genericRepository.SaveChangesAsync();
        return createdEntity;
    }

    public async Task<ICollection<ProductColor>> GetAllAsync()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<ProductColor> GetByIdAsync(int id)
    {
        if (!await _genericRepository.IsExistsAsync(id))
        {
            throw new EntityNotFoundException();
        }
        return await _genericRepository.GetByIdAsync(id);
    }

    public async  Task<bool> SoftDeleteAsync(int id)
    {
        var Entity = await GetByIdAsync(id);
        _genericRepository.SoftDelete(Entity);
        await _genericRepository.SaveChangesAsync();
        return true;
    }
}
