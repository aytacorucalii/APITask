using Final.BL.DTOs.ProductDTOs;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalPr.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet]

    public async Task<ICollection<Product>> GetAll()
    {
        return await _productService.GetAllAsync();
    }
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDTO createDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        };
        return StatusCode(StatusCodes.Status201Created, await _productService.CreateAsync(createDto));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _productService.GetByIdAsync(id));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status404NotFound, e.Message);
        }
    }
    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _productService.SoftDeleteAsync(id));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }

    [HttpPut("updatebook/{id}")]
    public async Task<IActionResult> Update(int id, ProductCreateDTO updateDTO)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _productService.UpdateAsync(id, updateDTO));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }
    [HttpPatch("updatebook/{id}")]
    public async Task<IActionResult> Edit(int id, ProductEditDTO EditDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _productService.EditAsync(id, EditDto));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }

    }
    [HttpPost("ImageUpload/{DTO}")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> ImageUpload([FromForm] ProductCreateDTO createDto)
    {
        var product = await _productService.CreateImageAsync(createDto);
        return Ok(product);
    }
}
