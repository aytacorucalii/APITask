using Ecommerce.BL.DTOs.ProductDTO;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommercePr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var employees = await _productService.GetAllAsync();
            return Ok(employees);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var employee = await _productService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }



        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<ActionResult<Product>> Create(ProductCreateDto Product)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return await _productService.CreateAsync(Product);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();

        }
    }
}
