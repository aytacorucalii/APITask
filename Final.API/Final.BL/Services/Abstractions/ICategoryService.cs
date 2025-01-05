using Final.BL.DTOs.CategoryDTOs;
using Final.BL.DTOs.ColorDTOs;
using Final.BL.DTOs.ProductDTOs;
using Final.Core.Entities;

namespace Final.BL.Services.Abstractions;

public interface ICategoryService
{
    Task<ICollection<Category>> GetAllAsync();
    Task<Category> CreateAsync(CategoryCreateDTO createDto);
    Task<Category> GetByIdAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> UpdateAsync(int id, CategoryCreateDTO entityDto);
    Task<bool> EditAsync(int id, CategoryCreateDTO editDTO);
}
