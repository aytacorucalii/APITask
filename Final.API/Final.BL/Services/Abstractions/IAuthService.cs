using Final.BL.DTOs.AppUserDTOs;

namespace Final.BL.Services.Abstractions;

public interface IAuthService
{
    Task<bool> RegisterAsync(AppUserCreateDTO entityCreateDto);
    Task<string> LoginAsync(AppUserLoginDTO entityLoginDto);
}
