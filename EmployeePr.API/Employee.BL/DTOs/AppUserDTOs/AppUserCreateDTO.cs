using FluentValidation;
using System.Text.RegularExpressions;

namespace EmployeePr.BL.DTOs.AppUserDTOs;

public class AppUserCreateDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
public class AppUserDTOValidation : AbstractValidator<AppUserCreateDTO>
{
    public AppUserDTOValidation()
    {
        RuleFor(b => b.FirstName).NotEmpty()
       .WithMessage("Name cannot be empty")
       .NotNull().WithMessage("Name cannot be null")
       .MaximumLength(30).WithMessage("Maximum length is 30");

        RuleFor(b => b.LastName).NotEmpty()
       .WithMessage("Surname cannot be empty")
       .NotNull().WithMessage("Surname cannot be null")
       .MaximumLength(50).WithMessage("Surname Maximum length is 50");

        RuleFor(b => b.PhoneNumber)
       .NotEmpty().WithMessage("Phone number cannot be empty")
       .NotNull().WithMessage("Phone number cannot be null")
       .Matches(@"\(\+994\)(50|51|55|70|77|90|99)-\d{3}-\d{2}-\d{2}$")
       .WithMessage("Enter a valid  phone number (+994)XX-XXX-XX-XX ");

        RuleFor(b => b.Email).Must(e => ValidEmailAddress(e)).WithMessage("Enter correct email address");

        RuleFor(b => b.Password)
       .NotEmpty()
       .WithMessage("Password cannot be empty")
       .MinimumLength(8)
       .WithMessage("Password must be at least 8 characters long")
       .Matches("[a-z]")
       .WithMessage("Password must contain at least one lowercase letter")
       .Matches("[0-9]")
       .WithMessage("Password must contain at least one digit");

        RuleFor(b => b.ConfirmPassword)
       .NotEmpty()
       .WithMessage("Confirm Password cannot be empty")
       .Equal(b => b.Password)
       .WithMessage("Passwords do not match");
    }

    public bool ValidEmailAddress(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        if (match.Success) { return true; }
        return false;
    }
}
