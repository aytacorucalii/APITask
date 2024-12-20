using WorksShop.BL.DTOs.WorkShopDTOs;
using WorksShop.Core.Entities;

namespace WorksShop.BL.Services.Abstractions;

public interface IWorkShopService
{
    Task<IEnumerable<Workshop>> GetAllAsync();
    Task<Workshop> GetByIdAsync(int id);
    Task<Workshop> CreateAsync(WorkShopCreateDTO Workshop);
    Task DeleteAsync(int id);
}
