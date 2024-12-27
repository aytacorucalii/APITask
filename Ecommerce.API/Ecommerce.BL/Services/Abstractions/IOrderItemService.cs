using Ecommerce.BL.DTOs.OrderItemDTO;
using Ecommerce.Core.Entities;

namespace Ecommerce.BL.Services.Abstractions;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItem>> GetAllAsync();
    Task<OrderItem> GetByIdAsync(int id);
    Task<OrderItem> CreateAsync(OrderItemCreateDto OrderItem);
    Task Update(OrderItem OrderItem);
    Task DeleteAsync(int id);
}
