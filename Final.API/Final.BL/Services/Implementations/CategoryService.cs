using AutoMapper;
using Final.BL.DTOs.CategoryDTOs;
using Final.BL.Exceptions.CommonExceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.DAL.Repositories.Abstractions;
using Final.DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Authorization;

namespace Final.BL.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }


    [Authorize(Policy = "Admin")]
    public async Task<Category> CreateAsync(CategoryCreateDTO createDto)
    {
        Category createdCategory = _mapper.Map<Category>(createDto);
        createdCategory.CreatedAt = DateTime.UtcNow.AddHours(4);
        var createdEntity = await _categoryRepository.CreateAsync(createdCategory);
        await _categoryRepository.SaveChangesAsync();
        return createdEntity;
    }


    public async Task<ICollection<Category>> GetAllAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async  Task<Category> GetByIdAsync(int id)
    {
        if (!await _categoryRepository.IsExistsAsync(id))
        {
            throw new EntityNotFoundException();
        }
        return await _categoryRepository.GetByIdAsync(id);
    }


    [Authorize(Policy = "Admin")]
    public async Task<bool> SoftDeleteAsync(int id)
    {

        var Entity = await GetByIdAsync(id);
        _categoryRepository.SoftDelete(Entity);
        await _categoryRepository.SaveChangesAsync();
        return true;
    }


    [Authorize(Policy = "Admin")]
    public async Task<bool> UpdateAsync(int id, CategoryCreateDTO entityDto)
    {
        var Entity = await GetByIdAsync(id);
        Category updated = _mapper.Map<Category>(entityDto);
        updated.UpdatedAt = DateTime.UtcNow.AddHours(4);
        updated.Id = id;
        _categoryRepository.Update(updated);
        await _categoryRepository.SaveChangesAsync();
        return true;
    }

    [Authorize(Policy = "Admin")]
    public async Task<bool> EditAsync(int id, CategoryCreateDTO editDTO)
    {
        var Entity = await GetByIdAsync(id);
        _mapper.Map(editDTO, Entity);

        Entity.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _categoryRepository.Update(Entity);
        await _categoryRepository.SaveChangesAsync();
        return true;
    }
}
