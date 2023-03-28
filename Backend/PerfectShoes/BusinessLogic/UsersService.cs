using Microsoft.EntityFrameworkCore;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public class UsersService : Service, IUsersService
    {
        public UsersService(DataContext context) : base(context) { }

        public User? Authenticate(AuthentificationDto authentificationDto)
        {
            if (authentificationDto.Email.EndsWith("@perfectshoes.com"))
            {
                return _context.Users.FirstOrDefault(e => authentificationDto.Email.Equals(e.Email) && authentificationDto.Password.Equals(e.Password));
            }
            else
            {
                return _context.Customers.Include(c => c.Address)
                    .Include(c => c.Orders).ThenInclude(o => o.LineItems).ThenInclude(p => p.Product)
                    .Include(c => c.Orders).ThenInclude(o => o.CreditCard)
                    .Include(c => c.CreditCard)
                    .FirstOrDefault(e => authentificationDto.Email.Equals(e.Email)
                        && authentificationDto.Password.Equals(e.Password));
            }
        }

        public bool InsertCustomer(UserDto userDto)
        {
            var user = new Customer
            {
                Email = userDto.Email,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
            };

            return InsertUser(user);
        }

        public bool InsertEmployee(EmployeeDto employeeDto)
        {
            var user = new Employee
            {
                Email = employeeDto.Email,
                Password = employeeDto.Password,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                IsAdmin = true,
                Role = employeeDto.Role,
            };

            return InsertUser(user);
        }

        private bool InsertUser(User user)
        {
            User? first = _context.Users.FirstOrDefault(e => user.Email.Equals(e.Email));

            if (first == null)
            {
                _context.Users.Add(user);
            }
            else if(first.Password == null)
            {
                first.FirstName = user.FirstName;
                first.LastName = user.LastName;
                first.Password = user.Password;
                _context.Entry(first).State= EntityState.Modified;
            }

            return _context.SaveChanges() > 0;
        }
    }
}
