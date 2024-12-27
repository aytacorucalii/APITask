using AutoMapper;
using Ecommerce.BL.DTOs.ProductDTO;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Repositories.Abstractions;

namespace Ecommerce.BL.Services.Impementation;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
      return await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }


    public async Task<Product> CreateAsync(ProductCreateDto productdto)
    {
        Product product = _mapper.Map<Product>(productdto);
        await _productRepository.CreateAsync(product);
        return product;
    }

    public async Task DeleteAsync(int id)
    {
       await _productRepository.DeleteAsync(id);
    }

    public async Task Update(Product productdto)
    {
        await _productRepository.Update(productdto);
    }
}
