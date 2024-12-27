using Ecommerce.BL.DTOs.OrderDTO;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommercePr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            var order = await _orderService.GetAllAsync();
            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Order>> Create(OrderCreateDto createOrder)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return await _orderService.CreateAsync(createOrder);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _orderService.DeleteAsync(id));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }

        }
        [HttpPut("updatebook/{id}")]
        public async Task<IActionResult> Update(int id, OrderCreateDto orderCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _orderService.Update(id, orderCreateDto));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
