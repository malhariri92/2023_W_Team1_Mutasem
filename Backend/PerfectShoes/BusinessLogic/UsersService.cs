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

        public bool InsertUser(UserDto userDto)
        {
            var user = new User
            {
                //Id = userDto.Id,
                Email = userDto.Email,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
            };
            //check to see if they are already in the database
            if (userDto.Type == "employee")
                return InsertEmployee(user);
            else return InsertCustomer(user);
        }
        private bool InsertEmployee(User user)
        {
            Employee? first = _context.Employees.FirstOrDefault(e => user.Email.Equals(e.Email) && e.Password == null);
            if (first != null)
            {
                //first.FirstName = user.FirstName;
                //first.LastName = user.LastName;
                first.Password = user.Password;
                //first.Role = "admin";
                //first.IsAdmin = true;
                _context.Entry(first).State = EntityState.Modified;
            }
            return _context.SaveChanges() > 0;
        }//end of InsertEmployee method

        private bool InsertCustomer(User user)
        {
            Customer? first = _context.Customers.FirstOrDefault(e => user.Email.Equals(e.Email));
            if (first == null)
            {
                first = new Customer // this ensures the object type is a customer
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                };
                _context.Users.Add(first);
            }
            else if (first.Password == null)
            {
                first.FirstName = user.FirstName;
                first.LastName = user.LastName;
                first.Password = user.Password;
                _context.Entry(first).State = EntityState.Modified;
            }
            return _context.SaveChanges() > 0;
        }//end of InsertCustomer method

        public bool AddEmployee(EmployeeDto employeeDto)
        {
            Employee employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Role = employeeDto.Role,
                IsAdmin = employeeDto.IsAdmin,
            };
            _context.Employees.Add(employee);
            return _context.SaveChanges() > 0;
        }
    }
}
