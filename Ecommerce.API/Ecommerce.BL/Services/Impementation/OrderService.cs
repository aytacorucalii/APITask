using AutoMapper;
using Ecommerce.BL.DTOs.OrderDTO;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Repositories.Abstractions;

namespace Ecommerce.BL.Services.Impementation;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task<Order> CreateAsync(OrderCreateDto department)
    {
        Order order = _mapper.Map<Order>(department);
        await _orderRepository.CreateAsync(order);
        return order;
    }

    public async Task DeleteAsync(int id)
    {
        var orderEntity = await GetByIdAsync(id);
        _orderRepository.DeleteAsync(orderEntity);
        await _orderRepository.SaveChangesAsync();
        return ;
    }



    public async Task Update(Order department)
    {
        await _orderRepository.Update(department);
    }
}

