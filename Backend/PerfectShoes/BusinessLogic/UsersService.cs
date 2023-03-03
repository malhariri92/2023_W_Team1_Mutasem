using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public class UsersService : Service, IUsersService
    {
        public UsersService(DataContext context) : base(context) { }

        public User? Authenticate(AuthentificationDto authentificationDto)
        {
            return _context.Users.FirstOrDefault(e => authentificationDto.Email.Equals(e.Email) && authentificationDto.Password.Equals(e.Password));
        }
    }
}
