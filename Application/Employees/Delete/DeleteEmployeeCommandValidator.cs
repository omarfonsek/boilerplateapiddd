using FluentValidation;

namespace Application.Employees.Delete
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(r => r.Id)
            .NotEmpty();
        }
    }
}
