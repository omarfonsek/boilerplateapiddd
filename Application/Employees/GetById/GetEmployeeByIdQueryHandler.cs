using Application.Employees.Common;
using Domain.Employees;
using ErrorOr;
using MediatR;

namespace Application.Employees.GetById
{
    internal sealed class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, ErrorOr<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<ErrorOr<EmployeeResponse>> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _employeeRepository.GetByIdAsync(query.Id) is not Employee employee)
            {
                return Error.NotFound("Employee.NotFound", "The employee with the provide Id was not found.");
            }

            return new EmployeeResponse(
                employee.EmployeeId,
                employee.FullName,
                employee.Salary,
                employee.Active);
        }
    }
}
