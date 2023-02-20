using PerfectShoes.Models;

namespace PerfectShoes.BusinessLogic
{
    public interface IEmployeeService
    {
        public Employee? AuthenticateAsEmployee(string email, string password);
    }
}
