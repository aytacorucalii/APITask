using Ecommerce.BL.DTOs.OrderDTO;
using Ecommerce.Core.Entities;

namespace Ecommerce.BL.Services.Abstractions;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int id);
    Task<OrderItem> CreateAsync(OrderCreateDto department);
    Task Update(Order department);
    Task DeleteAsync(int id);
}
