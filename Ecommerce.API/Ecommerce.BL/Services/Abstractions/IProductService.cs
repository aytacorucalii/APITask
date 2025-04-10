﻿using Ecommerce.BL.DTOs.ProductDTO;
using Ecommerce.Core.Entities;

namespace Ecommerce.BL.Services.Abstractions;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> CreateAsync(ProductCreateDto product);
    Task Update(Product product);
    Task DeleteAsync(int id);
}
