using EmployeePr.BL.DTOs.AppUserDTOs;

namespace EmployeePr.BL.Services.Abstractions;

public interface IAuthService
{
    Task<bool> RegisterAsync(AppUserCreateDTO appUserCreate);
    Task<bool> ConfirmEmailAsync(string userId, string token);
    Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDto);
    Task<bool> Login(LoginUserDTO loginUserDto);
    Task<bool> Logout();
}
