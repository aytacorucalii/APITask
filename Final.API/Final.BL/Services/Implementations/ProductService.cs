using AutoMapper;
using Final.BL.DTOs.ProductDTOs;
using Final.BL.Exceptions.CommonExceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace Final.BL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    [Authorize(Policy = "Admin")]
    public async Task<Product> CreateAsync(ProductCreateDTO createDto)
    {
        Product createdProduct = _mapper.Map<Product>(createDto);
        createdProduct.CreatedAt = DateTime.UtcNow.AddHours(4);
        var createdEntity = await _productRepository.CreateAsync(createdProduct);
        await _productRepository.SaveChangesAsync();
        return createdEntity; 
    }


    public async Task<ICollection<Product>> GetAllAsync()
    {
      return await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        if (!await _productRepository.IsExistsAsync(id))
        {
            throw new EntityNotFoundException();
        }
        return await _productRepository.GetByIdAsync(id);
    }


    [Authorize(Policy = "Admin")]
    public async Task<bool> SoftDeleteAsync(int id)
    {
        var Entity = await GetByIdAsync(id);
        _productRepository.SoftDelete(Entity);
        await _productRepository.SaveChangesAsync();
        return true;
    }


    [Authorize(Policy = "Admin")]
    public async Task<bool> UpdateAsync(int id, ProductCreateDTO entityDto)
    {
        var Entity = await GetByIdAsync(id);
        Product updated = _mapper.Map<Product>(entityDto);
        updated.UpdatedAt = DateTime.UtcNow.AddHours(4);
        updated.Id = id;
        _productRepository.Update(updated);
        await _productRepository.SaveChangesAsync();
        return true;
    }

    [Authorize(Policy = "Admin")]
    public async Task<bool> EditAsync(int id, ProductEditDTO entityDto)
    {
        var Entity = await GetByIdAsync(id);
        _mapper.Map(entityDto, Entity);

        Entity.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _productRepository.Update(Entity);
        await _productRepository.SaveChangesAsync();
        return true;
    }

    [Authorize(Policy = "Admin")]
    public async Task<Product> CreateImageAsync(ProductCreateDTO createDto)
    {
        Product createdProduct = _mapper.Map<Product>(createDto);
        createdProduct.CreatedAt = DateTime.UtcNow.AddHours(4);

       
        if (createDto.Image != null)
        {
            var imageFileName = $"{Guid.NewGuid()}_{createDto.Image.FileName}";
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageFileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await createDto.Image.CopyToAsync(stream);
            }

            createdProduct.ImagePath = $"/images/{imageFileName}"; 
        }

        var createdEntity = await _productRepository.CreateAsync(createdProduct);
        await _productRepository.SaveChangesAsync();
        return createdEntity;
    }

}


