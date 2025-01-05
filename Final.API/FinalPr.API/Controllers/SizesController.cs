using Final.BL.DTOs.SizeDTOs;
using Final.BL.Services.Abstractions;
using Final.BL.Services.Implementations;
using Final.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinalPr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        public async Task<ICollection<Size>> GetAll()
        {
            return await _sizeService.GetAllAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SizeCreateDTO createDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return StatusCode(StatusCodes.Status201Created, await _sizeService.CreateAsync(createDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _sizeService.GetByIdAsync(id));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }


    }
}
