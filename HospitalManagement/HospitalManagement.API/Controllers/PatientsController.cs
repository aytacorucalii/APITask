using HospitalManagement.BL.DTOs.PatientDTOs;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }
    [HttpGet]
    public async Task<ICollection<Patient>> GetAll()
    {
        return await _patientService.GetAllAsync();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _patientService.GetByIdAsync(id));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status404NotFound, e.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Create(PatientCreateDTO createDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        };
        return StatusCode(StatusCodes.Status201Created, await _patientService.CreateAsync(createDto));
    }
    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _patientService.SoftDeleteAsync(id));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }
    [HttpPut("updatebook/{id}")]
    public async Task<IActionResult> Update(int id, PatientCreateDTO updateDTO)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _patientService.UpdateAsync(id, updateDTO));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }
    [HttpPatch("updatebook/{id}")]
    public async Task<IActionResult> Edit(int id, PatientCreateDTO EditDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _patientService.EditAsync(id, EditDto));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }
    }
