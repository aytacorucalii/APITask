using AutoMapper;
using Final.BL.DTOs.AppUserDTOs;
using Final.BL.Exceptions.CommonExceptions;
using Final.BL.ExternalServices.Abstractions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final.BL.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;

    public AuthService(UserManager<AppUser> userManager, IMapper mapper, IJwtTokenService jwtTokenService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtTokenService = jwtTokenService;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<string> LoginAsync(AppUserLoginDTO entityLoginDto)
    {
        AppUser? existingUser = await _userManager.FindByNameAsync(entityLoginDto.UserName);
        if (existingUser == null) throw new EntityNotFoundException();

        bool result = await _userManager.CheckPasswordAsync(existingUser, entityLoginDto.Password);
        if (!result) throw new Exception("Username or password is wrong");

        string token = _jwtTokenService.GenerateToken(existingUser);
        return token;
    }

    public async Task<bool> RegisterAsync(AppUserCreateDTO entityCreateDto)
    {
        AppUser user = _mapper.Map<AppUser>(entityCreateDto);
        var result = await _userManager.CreateAsync(user, entityCreateDto.Password);
        if (!result.Succeeded) throw new Exception("Could not create user");

        return true;
    }

    public async Task CreateRoles()
    {
        if (!await _roleManager.RoleExistsAsync("Admin"))
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });

        if (!await _roleManager.RoleExistsAsync("Manager"))
            await _roleManager.CreateAsync(new IdentityRole { Name = "Manager" });

        if (!await _roleManager.RoleExistsAsync("User"))
            await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
    }

    public async Task<IActionResult> CreateAdmin()
    {
        AppUser user = new AppUser
        {
            UserName = "SuperAdmin",
            Email = "admin@gmail.com",
            FirstName = "Aytac",
            LastName = "Orucalii"
        };

        var result = await _userManager.CreateAsync(user, "Admin123!");
        if (!result.Succeeded)
        {
            return new BadRequestObjectResult("Admin creation failed");
        }

        await _userManager.AddToRoleAsync(user, "Admin");
        return new OkObjectResult("Admin created successfully");
    }
}
    