using EmployeePr.BL.DTOs.AppUserDTOs;
using EmployeePr.BL.Services.Abstractions;
using EmployeePr.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProj.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthsController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    public AuthsController(IAuthService authService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _authService = authService;
        _signInManager = signInManager;
        _userManager = userManager;
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
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDTO UserLoginDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _authService.LoginAsync(UserLoginDto));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }

}
    //[HttpPost("Logout")]
    //public async Task<IActionResult> Logout()
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return StatusCode(StatusCodes.Status400BadRequest, ModelState);
    //    }
    //    try
    //    {
    //        return StatusCode(StatusCodes.Status200OK, await _authService.Logout());
    //    }
    //    catch (Exception e)
    //    {

    //        return StatusCode(StatusCodes.Status400BadRequest, e.Message);
    //    }
    //}

