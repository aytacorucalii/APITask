using System.Text.RegularExpressions;
using FluentValidation;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Enums;

namespace HospitalManagement.BL.DTOs.PatientDTOs;

public class PatientCreateDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DOB { get; set; }
    public Gender Gender { get; set; }
    public BloodGroup BloodGroup { get; set; }
    public string? PhoneNumber { get; set; }
    public string? SeriaNumber { get; set; }
    public string? RegistrationAddress { get; set; }
    public string? CurrentAddress { get; set; }
    public int InsuranceId { get; set; }
    public string? Email { get; set; }
     public class InsureCreateDTOValidation : AbstractValidator<PatientCreateDTO>
    {
        public InsureCreateDTOValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null")
                .MaximumLength(128).WithMessage("Name cannot exceed 128 characters.");

            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("Surname cannot be empty")
                .NotNull().WithMessage("Surname cannot be null")
                .MaximumLength(128).WithMessage("Surname cannot exceed 128 characters.");

            RuleFor(b => b.Email).Must(b => BeValidEmailAddress(b))
                .WithMessage("Enter correct email address");
            RuleFor(b => b.PhoneNumber)
                .Must(b => BeValidPhoneNumber(b))
                .WithMessage("Enter a valid phone number");

        }
        public bool BeValidPhoneNumber(string phoneNumber)
        {

            Regex regex = new Regex(@"^\+994-\d{2}-\d{3}-\d{2}-\d{2}$");//+994-70-546-75-01
            Match match = regex.Match(phoneNumber);
            return match.Success;
        }
        public bool BeValidEmailAddress(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,10})+)$");//aytac2@gmail.com
            Match match = regex.Match(email);
            if (match.Success) { return true; }
            return false;
        }
     }
    
}
