using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public interface IUsersService
    {
        public User? Authenticate(AuthentificationDto authentificationDto);

        public bool InsertCustomer(UserDto userDto);

        public bool InsertEmployee(EmployeeDto userDto);
    }
}
