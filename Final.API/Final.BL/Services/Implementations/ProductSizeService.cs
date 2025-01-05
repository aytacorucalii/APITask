using AutoMapper;
using Final.BL.DTOs.ProductSizeDTOs;
using Final.BL.Exceptions.CommonExceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.DAL.Repositories.Abstractions;

namespace Final.BL.Services.Implementations
{
    public class ProductSizeService : IProductSizeService
    { 
        private readonly IGenericRepository<ProductSize> _genericRepository;
        private readonly IMapper _mapper;
        public ProductSizeService(IGenericRepository<ProductSize> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ProductSize> CreateAsync(ProductSizeCreateDTO createDto)
        {
            ProductSize createdProduct = _mapper.Map<ProductSize>(createDto);
            var createdEntity = await _genericRepository.CreateAsync(createdProduct);
            await _genericRepository.SaveChangesAsync();
            return createdEntity;
        }

        public async Task<ICollection<ProductSize>> GetAllAsync()
        {
           return await _genericRepository.GetAllAsync();
        }

        public async Task<ProductSize> GetByIdAsync(int id)
        {
            if (!await _genericRepository.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var Entity = await GetByIdAsync(id);
            _genericRepository.SoftDelete(Entity);
            await _genericRepository.SaveChangesAsync();
            return true;
        }
    }
}
