using Ecommerce.Core.Entities;
using Ecommerce.DAL.DAL;
using Ecommerce.DAL.Repositories.Abstractions;

namespace Ecommerce.DAL.Repositories.Implementations;

public class ProductRepository : GenericRepository<Product>, IGenericRepository<Product>
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
