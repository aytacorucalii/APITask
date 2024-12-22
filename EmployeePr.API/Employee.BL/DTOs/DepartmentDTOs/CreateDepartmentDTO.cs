using EmployeePr.Core.Entities;
using FluentValidation;

namespace EmployeePr.BL.DTOs.DepartmentDTOs;

public class CreateDepartmentDTO
{
    public string Name { get; set; }

    public ICollection<Employee>? Employees { get; set; }
}

public class CreateDepartmentDTOValidator : AbstractValidator<Department>
{
    public CreateDepartmentDTOValidator()
    {
        RuleFor(E => E.Name).NotEmpty()
              .WithMessage("Name cannot be empty")
              .NotNull().WithMessage("Name cannot be null")
              .MaximumLength(128).WithMessage("Maximum length is 128");

    }
}
