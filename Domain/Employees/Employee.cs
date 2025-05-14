using Domain.Primitives;

namespace Domain.Employees
{
    public sealed class Employee : AggregateRoot
    {
        public Employee(string employeeId, string fullName, float salary, bool active)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            Salary = salary;
            Active = active;
        }

        public string EmployeeId { get; private set; }
        public string FullName { get; private set; }
        public float Salary { get; private set; }
        public bool Active { get; set; }

        public static Employee UpdateEmployee(string employeeId, string fullName, float salary, bool active)
        {
            return new Employee(employeeId, fullName, salary, active);
        }
    }
}
