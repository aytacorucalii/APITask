using WorksShop.BL.DTOs.WorkShopDTOs;
using WorksShop.BL.Services.Abstractions;
using WorksShop.Core.Entities;
using WorksShop.DAL.Repositories.Abstractions;
using WorksShop.DAL.Repositories.Implementations;

namespace WorksShop.BL.Services.Implementations;

public class WorkService : IWorkShopService
{
    private readonly IWorkShopRepository _workShopRepository;
    public WorkService(IWorkShopRepository workShopRepository)
    {
        _workShopRepository= workShopRepository;
    }
    public async Task<IEnumerable<Workshop>> GetAllAsync()
    {
      return await _workShopRepository.GetAllAsync();
    }

    public async Task<Workshop> GetByIdAsync(int id)
    {
       return await _workShopRepository.GetByIdAsync(id);
    }


    public async Task<Workshop> CreateAsync(WorkShopCreateDTO Workshop)
    {
        Workshop workshop = new Workshop()
        {
            Title = Workshop.Title,
            Description = Workshop.Description
        };

        await _workShopRepository.CreateAsync(workshop);
        await _workShopRepository.SaveChangesAsync();
       return workshop;

    }

    public async Task DeleteAsync(int id)
    {
        await _workShopRepository.DeleteAsync(id);

    }

}
