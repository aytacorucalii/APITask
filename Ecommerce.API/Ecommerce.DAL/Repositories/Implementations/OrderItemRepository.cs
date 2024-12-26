using Ecommerce.Core.Entities;
using Ecommerce.DAL.DAL;
using Ecommerce.DAL.Repositories.Abstractions;

namespace Ecommerce.DAL.Repositories.Implementations;

public class OrderItemRepository : GenericRepository<OrderItem>, IGenericRepository<OrderItem>
{
    public OrderItemRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
