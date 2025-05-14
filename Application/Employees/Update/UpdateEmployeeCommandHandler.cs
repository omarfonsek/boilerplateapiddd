using Domain.Employees;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Employees.Update
{
    internal sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ErrorOr<Unit>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            if (!await _employeeRepository.ExistsAsync(command.EmployeeId))
            {
                return Error.NotFound("Employee.NotFound", "The employee with the provide Id was not found.");
            }

            Employee employee = Employee.UpdateEmployee(
                command.EmployeeId,
                command.FullName,
                command.Salary,
                command.Active);

            _employeeRepository.Update(employee);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
