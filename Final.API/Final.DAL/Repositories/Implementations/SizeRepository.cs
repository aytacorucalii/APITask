using Final.Core.Entities;
using Final.DAL.DAL;
using Final.DAL.Repositories.Abstractions;

namespace Final.DAL.Repositories.Implementations;

public class SizeRepository : GenericRepository<Size>, ISizeRepository
{
    public SizeRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
