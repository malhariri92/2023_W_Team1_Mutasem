using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public interface IUsersService
    {
        public User? Authenticate(AuthentificationDto authentificationDto);

        public bool InsertUser(UserDto userDto);

        public bool UpdatePassword(UserDto userDto);

    }
}
