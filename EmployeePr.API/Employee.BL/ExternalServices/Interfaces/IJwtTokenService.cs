using EmployeePr.Core.Entities;

namespace EmployeePr.BL.ExternalServices.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(AppUser appUser);
}
