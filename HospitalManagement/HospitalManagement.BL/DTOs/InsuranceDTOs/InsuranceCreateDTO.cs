using FluentValidation;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.DTOs.InsuranceDTOs;

public class InsuranceCreateDTO
{
    public string? PersonInsurance { get; set; }
    public float Discount { get; set; }
    public ICollection<Patient>? Patients { get; set; }
    public class InsuranceCreateDTOValidation : AbstractValidator<InsuranceCreateDTO>
    {
        public InsuranceCreateDTOValidation()
        {
            RuleFor(p => p.PersonInsurance)
                .NotEmpty().WithMessage("PersonInsurance cannot be empty")
                .NotNull().WithMessage("PersonInsurance cannot be null")
                .MaximumLength(128).WithMessage("PersonInsurance cannot exceed 128 characters.");
        }
    }
}
