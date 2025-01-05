using Final.BL.DTOs.ProductColorDTOs;
using Final.BL.DTOs.ProductSizeDTOs;
using Final.Core.Entities;

namespace Final.BL.Services.Abstractions;

public interface IProductSizeService
{
    Task<ICollection<ProductSize>> GetAllAsync();
    Task<ProductSize> CreateAsync(ProductSizeCreateDTO createDto);
    Task<ProductSize> GetByIdAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
}
