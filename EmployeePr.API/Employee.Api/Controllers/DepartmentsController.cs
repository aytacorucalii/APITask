using EmployeePr.BL.Services.Abstractions;
using EmployeePr.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProj.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetById(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

 
        [HttpPost]
        public async Task<ActionResult> Create( Department department)
        {
            await _departmentService.CreateAsync(department);
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }

    }
}
