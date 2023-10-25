using EmployeesOps.BLL.Dtos;
using EmployeesOps.BLL.Helpers;
using FluentValidation;

namespace EmployeesOps.BLL.Validators
{
    public class EmployeesInsertValidator : AbstractValidator<EmployeeInsertDto>
    {
        public EmployeesInsertValidator()
        {
            RuleFor(x => x.Names)
                 .NotNull().WithMessage("El campo {PropertyName} es obligatorio.")
                 .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacío.")
                 .MaximumLength(80).WithMessage("El campo {PropertyName} no puede tener más de 80 caracteres.");

            RuleFor(x => x.LastNames)
                .NotNull().WithMessage("El campo {PropertyName} es obligatorio.")
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacío.")
                .MaximumLength(80).WithMessage("El campo {PropertyName} no puede tener más de 80 caracteres.");

            RuleFor(x => x.IdentificationNumber)
                .NotNull().WithMessage("El campo {PropertyName} es obligatorio.")
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacío.")
                .MaximumLength(20).WithMessage("El campo {PropertyName} no puede tener más de 20 caracteres.");

            RuleFor(x => x.BirthDate)
                .NotNull().WithMessage("El campo {PropertyName} es obligatorio.")
                .Must(AgeValidator.IsAdult).WithMessage("El empleado debe ser mayor de 18 años.");

            RuleFor(x => x.Salary)
                .NotNull().WithMessage("El campo {PropertyName} es obligatorio.");

            RuleFor(x => x.EntryDate)
                .NotNull().WithMessage("El campo {PropertyName} es obligatorio.");
        }
    }
}
