using Final.BL.DTOs.ProductDTOs;
using Final.Core.Entities;

namespace Final.BL.Services.Abstractions;

public interface IProductService
{
    Task<ICollection<Product>> GetAllAsync();
    Task<Product> CreateAsync(ProductCreateDTO createDto);
    Task<Product> GetByIdAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> UpdateAsync(int id, ProductCreateDTO entityDto);
    Task<bool> EditAsync(int id, ProductEditDTO entityDto);
    Task<Product> CreateImageAsync(ProductCreateDTO createDto);
}
