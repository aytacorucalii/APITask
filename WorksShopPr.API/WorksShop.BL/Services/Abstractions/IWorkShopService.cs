using WorksShop.Core.Entities;

namespace WorksShop.BL.Services.Abstractions;

public interface IWorkShopService
{
    Task<IEnumerable<WorkShop>> GetAllAsync();
    Task<WorkShop> GetByIdAsync(int id);

}
