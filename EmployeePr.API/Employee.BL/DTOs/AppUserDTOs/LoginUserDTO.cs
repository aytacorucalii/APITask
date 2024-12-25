using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeePr.BL.DTOs.AppUserDTOs;

public class LoginUserDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class LoginUserDTOValidation : AbstractValidator<LoginUserDTO>
{
    public LoginUserDTOValidation()
    {
    
      RuleFor(b => b.Password)
     .NotEmpty()
     .WithMessage("Password cannot be empty")
     .MinimumLength(8)
     .WithMessage("Password must be at least 8 characters long")
     .Matches("[a-z]")
     .WithMessage("Password must contain at least one lowercase letter")
     .Matches("[0-9]")
     .WithMessage("Password must contain at least one digit");
    }
  
}

