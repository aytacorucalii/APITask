using WorksShop.Core.Entities;
using WorksShop.DAL.DAL;
using WorksShop.DAL.Repositories.Abstractions;

namespace WorksShop.DAL.Repositories.Implementations;

public class WorkShopRepository : GenericRepository<Workshop>, IWorkShopRepository
{
    public WorkShopRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
