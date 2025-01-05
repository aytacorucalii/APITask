using Final.BL.DTOs.ColorDTOs;
using Final.BL.DTOs.ProductDTOs;
using Final.BL.DTOs.SizeDTOs;
using Final.Core.Entities;

namespace Final.BL.Services.Abstractions;

public interface ISizeService
{
    Task<ICollection<Size>> GetAllAsync();
    Task<Size> CreateAsync(SizeCreateDTO createDto);
    Task<Size> GetByIdAsync(int id);
    Task<bool> EditAsync(int id, SizeCreateDTO editDTO);

}
