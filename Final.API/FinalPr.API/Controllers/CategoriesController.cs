using Final.BL.DTOs.CategoryDTOs;
using Final.BL.Services.Abstractions;
using Final.BL.Services.Implementations;
using Final.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinalPr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
       
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ICollection<Category>> GetAll()
        {
            return await _categoryService.GetAllAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO createDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return StatusCode(StatusCodes.Status201Created, await _categoryService.CreateAsync(createDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _categoryService.GetByIdAsync(id));
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
                return StatusCode(StatusCodes.Status200OK, await _categoryService.SoftDeleteAsync(id));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPut("updatebook/{id}")]
        public async Task<IActionResult> Update(int id, CategoryCreateDTO updateDTO)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _categoryService.UpdateAsync(id, updateDTO));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
        [HttpPatch("updatebook/{id}")]
        public async Task<IActionResult> Edit(int id, CategoryCreateDTO EditDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _categoryService.EditAsync(id, EditDto));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
