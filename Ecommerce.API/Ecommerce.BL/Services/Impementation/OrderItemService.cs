using AutoMapper;
using Ecommerce.BL.DTOs.OrderItemDTO;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Repositories.Abstractions;

namespace Ecommerce.BL.Services.Impementation;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;


    public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync()
    {
       return await _orderItemRepository.GetAllAsync();

    }

    public async Task<OrderItem> GetByIdAsync(int id)
    {
        return await _orderItemRepository.GetByIdAsync(id);
    }

    public async Task<OrderItem> CreateAsync(OrderItemCreateDto orderItemDto)
    {
        OrderItem orderItem = _mapper.Map<OrderItem>(orderItemDto);
        await _orderItemRepository.CreateAsync(orderItem);
        return orderItem;

    }

    public async Task DeleteAsync(int id)
    {
         await _orderItemRepository.DeleteAsync(id);
    }

    public async Task Update(OrderItem department)
    {
       await _orderItemRepository.Update(department);
    }
}
