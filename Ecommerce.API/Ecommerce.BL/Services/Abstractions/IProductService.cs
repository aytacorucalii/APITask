using Ecommerce.BL.DTOs.ProductDTO;
using Ecommerce.Core.Entities;

namespace Ecommerce.BL.Services.Abstractions;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> CreateAsync(ProductCreateDto department);
    Task Update(Product department);
    Task DeleteAsync(int id);
}
