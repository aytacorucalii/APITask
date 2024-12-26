using Ecommerce.BL.DTOs.ProductDTO;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Repositories.Abstractions;

namespace Ecommerce.BL.Services.Impementation;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Product> CreateAsync(ProductCreateDto department)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Product department)
    {
        throw new NotImplementedException();
    }
}
