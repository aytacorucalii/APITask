using EmployeePr.BL.DTOs.EmployeeDTOs;
using EmployeePr.BL.Services.Abstractions;
using EmployeePr.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProj.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{

    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
    {
        var employees = await _employeeService.GetAllAsync();
        return Ok(employees);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetById(int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }


    [HttpPost]
    public async Task<ActionResult<Employee>> Create(CreateEmployeeDTO createEmployee)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        };
        return await _employeeService.CreateAsync(createEmployee);

    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        
        await _employeeService.DeleteAsync(id);
        return NoContent();

    }
}
