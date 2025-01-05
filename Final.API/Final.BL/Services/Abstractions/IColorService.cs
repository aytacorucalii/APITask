using Final.BL.DTOs.ColorDTOs;
using Final.BL.DTOs.ProductDTOs;
using Final.Core.Entities;

namespace Final.BL.Services.Abstractions;

public interface IColorService
{
    Task<ICollection<Color>> GetAllAsync();
    Task<Color> CreateAsync(ColorCreateDTO createDto);
    Task<Color> GetByIdAsync(int id);
}
