using Final.Core.Entities;
using Final.DAL.DAL;
using Final.DAL.Repositories.Abstractions;

namespace Final.DAL.Repositories.Implementations;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
