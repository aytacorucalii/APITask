using Microsoft.AspNetCore.Mvc;
using WorksShop.BL.DTOs.WorkShopDTOs;
using WorksShop.BL.Services.Abstractions;
using WorksShop.Core.Entities;

namespace WorkShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkShopsController : ControllerBase
{
    private readonly IWorkShopService _workShopService;
    public WorkShopsController(IWorkShopService workShopService)
    {
        _workShopService = workShopService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workshop>>> GetAll()
    {
        var result = await _workShopService.GetAllAsync();
        return Ok(result);

    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Workshop>> GetByIdAsync(int id)
    {
        var result = await _workShopService.GetByIdAsync(id);
        if (result == null) 
        {
            return NotFound();  
        }
        return Ok(result);
        
    }
    [HttpPost]
    public async Task<ActionResult<Workshop>> CreateAsync(WorkShopCreateDTO Workshop)
    { 
        return await _workShopService.CreateAsync(Workshop);
        
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Workshop>> DeleteAsync(int id)
    {
         await _workShopService.DeleteAsync(id);
        return Ok();
    }
}

