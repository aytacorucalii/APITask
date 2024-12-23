using AutoMapper;
using EmployeePr.BL.DTOs.AppUserDTOs;
using EmployeePr.BL.Services.Abstractions;
using EmployeePr.BL.Utilities.Enums;
using EmployeePr.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePr.BL.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    public AuthService(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    public async Task<bool> RegisterAsync(AppUserCreateDTO appUserCreate)
    {
        AppUser userCreate = _mapper.Map<AppUser>(appUserCreate);
        var result = await _userManager.CreateAsync(userCreate, appUserCreate.Password);
        if (!result.Succeeded)
        {
            throw new Exception("Could not create user");
        }
        return true;
    }


    public async Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDto)
    {
        var user = await _userManager.FindByEmailAsync(changePasswordDto.Email);
        if (user == null) return false;

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, resetToken, changePasswordDto.NewPassword);

        return result.Succeeded;
    }


    public async Task<bool> ConfirmEmailAsync(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return false;

        var result = await _userManager.ConfirmEmailAsync(user, token);
        return result.Succeeded;
    }
    public async Task<bool> Login(LoginUserDTO loginUserDto)
    {
        AppUser? user = await _userManager.FindByNameAsync(loginUserDto.Email);
        if (user != null)
        {
            user = await _userManager.FindByNameAsync(loginUserDto.Email);
        }
        if (user == null)
        {
            throw new Exception("Please enter Email or Username");
        }
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDto.Password, loginUserDto.IsPersistent = true);
        if (!result.Succeeded) 
        {
            throw new Exception("Something went wrong");
        }
        return true;

    }

    public async  Task<bool> Logout()
    {
        await _signInManager.SignOutAsync();
        return true;
    }
    //public async Task CreateRoles()
    //{
    //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
    //    await _roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
    //    await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
    //}
    public async Task<bool> CreateAdmin()
    {
        AppUser user = new AppUser();
        user.UserName = "SuperAdmin";
        user.Email = "admin@code.com";
        user.FirstName = "Test";
        user.LastName = "Testov";
        var result = await _userManager.CreateAsync(user, "Admin123!");
       
        await _userManager.AddToRoleAsync(user, RoleEnum.Admin.ToString());
        return true;
    }
}
