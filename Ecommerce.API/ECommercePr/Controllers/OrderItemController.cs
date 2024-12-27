using Ecommerce.BL.DTOs.OrderItemDTO;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommercePr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetAll()
        {
            var orderItem = await _orderItemService.GetAllAsync();
            return Ok(orderItem);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetById(int id)
        {
            var orderItem = await _orderItemService.GetByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }
        [HttpPost("Create")]
        public async Task<ActionResult<OrderItem>> Create(OrderItemCreateDto orderItemcreate)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return await _orderItemService.CreateAsync(orderItemcreate);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _orderItemService.DeleteAsync(id);
            return NoContent();

        }
    }
}
