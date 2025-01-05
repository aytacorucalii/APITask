using Final.BL.DTOs.ColorDTOs;
using Final.BL.Services.Abstractions;
using Final.BL.Services.Implementations;
using Final.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalPr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<ICollection<Color>> GetAll()
        {
            return await _colorService.GetAllAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ColorCreateDTO createDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return StatusCode(StatusCodes.Status201Created, await _colorService.CreateAsync(createDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _colorService.GetByIdAsync(id));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }
      
        
    }
}
