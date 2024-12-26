using Ecommerce.BL.DTOs.OrderItemDTO;
using Ecommerce.Core.Entities;

namespace Ecommerce.BL.Services.Abstractions;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItem>> GetAllAsync();
    Task<OrderItem> GetByIdAsync(int id);
    Task<OrderItem> CreateAsync(OrderItemCreateDto department);
    Task Update(OrderItem department);
    Task DeleteAsync(int id);
}
