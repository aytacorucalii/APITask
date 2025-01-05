using Final.BL.DTOs.CategoryDTOs;
using Final.BL.DTOs.ProductColorDTOs;
using Final.Core.Entities;
using Final.DAL.Repositories.Abstractions;

namespace Final.BL.Services.Abstractions;

public interface IProductColorService
{
    Task<ICollection<ProductColor>> GetAllAsync();
    Task<ProductColor> CreateAsync(ProductColorCreateDTO createDto);
    Task<ProductColor> GetByIdAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
}
