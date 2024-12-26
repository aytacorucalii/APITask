using Ecommerce.Core.Entities;
using Ecommerce.DAL.DAL;
using Ecommerce.DAL.Repositories.Abstractions;

namespace Ecommerce.DAL.Repositories.Implementations;

public class OrderRepository : GenericRepository<Order>, IGenericRepository<Order>
{
    public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
