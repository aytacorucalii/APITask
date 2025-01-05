using Final.Core.Entities;

namespace Final.BL.ExternalServices.Abstractions
{
    public interface IJwtTokenService
    {
        string GenerateToken(AppUser appUser);
    }
}
