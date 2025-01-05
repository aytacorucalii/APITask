using Final.Core.Entities;
using Final.DAL.DAL;
using Final.DAL.Repositories.Abstractions;

namespace Final.DAL.Repositories.Implementations;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
