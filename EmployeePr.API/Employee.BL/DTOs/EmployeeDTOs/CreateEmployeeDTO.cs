using EmployeePr.Core.Entities;
using FluentValidation;

namespace EmployeePr.BL.DTOs.EmployeeDTOs;

public class CreateEmployeeDTO
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public int DepartmentId {  get; set; }
}

public class CreateEmployeeValidator : AbstractValidator<Employee>
{
    public CreateEmployeeValidator()
    {
        RuleFor(E=>E.Name).NotEmpty()
              .WithMessage("Name cannot be empty")
              .NotNull().WithMessage("Name cannot be null")
              .MaximumLength(128).WithMessage("Maximum length is 128");
        RuleFor(E => E.SurName).NotEmpty()
            .WithMessage("Name cannot be empty")
            .NotNull().WithMessage("Name cannot be null")
            .MaximumLength(128).WithMessage("Maximum length is 128");

    }
}