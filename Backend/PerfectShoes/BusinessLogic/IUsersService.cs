using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public interface IUsersService
    {
        public User? Authenticate(AuthentificationDto authentificationDto);

        public bool InsertEmployee(EmployeeDto employeeDto);
    }
}
