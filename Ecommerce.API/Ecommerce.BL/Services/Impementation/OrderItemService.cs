using Ecommerce.BL.DTOs.OrderItemDTO;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Repositories.Abstractions;

namespace Ecommerce.BL.Services.Impementation;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public Task<OrderItem> CreateAsync(OrderItemCreateDto department)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderItem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderItem> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(OrderItem department)
    {
        throw new NotImplementedException();
    }
}
