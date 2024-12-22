using AutoMapper;
using EmployeePr.BL.DTOs.AppUserDTOs;
using EmployeePr.BL.Services.Abstractions;
using EmployeePr.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace EmployeePr.BL.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    public AuthService(IMapper mapper, UserManager<AppUser> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
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

    
}
