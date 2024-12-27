using Ecommerce.BL.DTOs.OrderDTO;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.BL.Services.Abstractions;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int id);
    Task<Order> CreateAsync(OrderCreateDto order);
    Task Update(int id ,Order order);
    Task DeleteAsync(int id);


}
