using PerfectShoes.Models;

namespace PerfectShoes.BusinessLogic
{
    public class EmployeeService : Service, IEmployeeService
    {
        public EmployeeService(DataContext context) : base(context)
        {
        }

        public Employee? AuthenticateAsEmployee(string email, string password)
        {
            return this._context.Employees.FirstOrDefault(employee => employee.Email == email && employee.Password == password);
        }
    }
}
