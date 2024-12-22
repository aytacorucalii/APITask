using EmployeePr.BL.DTOs.AppUserDTOs;
using EmployeePr.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProj.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthsController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthsController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(AppUserCreateDTO appUserCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            return StatusCode(StatusCodes.Status201Created, await _authService.RegisterAsync(appUserCreateDto));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }
}
