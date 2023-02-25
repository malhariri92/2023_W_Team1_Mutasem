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
            return _context.Employees.FirstOrDefault(e => email.Equals(e.Email) && password.Equals(e.Password));
        }
    }
}
