using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeePr.BL.DTOs.AppUserDTOs;

public class LoginUserDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsPersistent { get; set; }
}
public class LoginUserDTOValidation : AbstractValidator<LoginUserDTO>
{
    public LoginUserDTOValidation()
    {
      RuleFor(b => b.Email).Must(e => ValidEmailAddress(e))
     .WithMessage("Enter correct email address");

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
    public bool ValidEmailAddress(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        if (match.Success) { return true; }
        return false;
    }
}

