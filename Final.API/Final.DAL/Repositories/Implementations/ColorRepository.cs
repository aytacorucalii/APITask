using Final.Core.Entities;
using Final.DAL.DAL;
using Final.DAL.Repositories.Abstractions;
namespace Final.DAL.Repositories.Implementations;

public class ColorRepository : GenericRepository<Color>, IColorRepository
{
    public ColorRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
