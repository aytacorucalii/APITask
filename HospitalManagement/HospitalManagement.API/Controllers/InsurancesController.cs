using HospitalManagement.BL.DTOs.InsuranceDTOs;
using HospitalManagement.BL.DTOs.PatientDTOs;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.BL.Services.Implementations;
using HospitalManagement.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InsurancesController : ControllerBase
{
    private readonly IInsureService _insureService;

    public InsurancesController(IInsureService insureService)
    {
        _insureService = insureService;
    }

    [HttpGet]
    public async Task<ICollection<Insurance>> GetAll()
    {
        return await _insureService.GetAllAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _insureService.GetByIdAsync(id));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status404NotFound, e.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Create(InsuranceCreateDTO createDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        };
        return StatusCode(StatusCodes.Status201Created, await _insureService.CreateAsync(createDto));
    }
}
