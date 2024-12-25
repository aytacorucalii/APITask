using EmployeePr.BL.DTOs.AppUserDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePr.BL.Services.Abstractions;

public interface IAuthService
{
    Task<bool> RegisterAsync(AppUserCreateDTO appUserCreate);
    Task<bool> ConfirmEmailAsync(string userId, string token);
    Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDto);
   
    Task<string> LoginAsync(LoginUserDTO entityLoginDto);
    Task<bool> Logout();
}
