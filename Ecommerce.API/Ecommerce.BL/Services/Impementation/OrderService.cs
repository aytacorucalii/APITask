using Ecommerce.BL.DTOs.OrderDTO;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Repositories.Abstractions;

namespace Ecommerce.BL.Services.Impementation;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<OrderItem> CreateAsync(OrderCreateDto department)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Order department)
    {
        throw new NotImplementedException();
    }
}
