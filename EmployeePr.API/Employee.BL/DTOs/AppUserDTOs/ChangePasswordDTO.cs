using FluentValidation;
using System.Text.RegularExpressions;

namespace EmployeePr.BL.DTOs.AppUserDTOs;

public class ChangePasswordDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string NewPassword { get; set; }

}
public class ChangePasswordDTOValidation : AbstractValidator<ChangePasswordDTO>
{
    public ChangePasswordDTOValidation()
    {
        RuleFor(b => b.Email).Must(e => ValidEmailAddress(e))
            .WithMessage("Enter correct email address");
    }

    public bool ValidEmailAddress(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        if (match.Success) { return true; }
        return false;
    }
}
