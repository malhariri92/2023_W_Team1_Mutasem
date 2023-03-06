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
            return _context.Users.FirstOrDefault(e => authentificationDto.Email.Equals(e.Email) && authentificationDto.Password.Equals(e.Password));
        }

        public bool InsertEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                //Id = employeeDto.Id,
                Email = employeeDto.Email,
                Password = employeeDto.Password,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Role = employeeDto.Role,
                IsAdmin = employeeDto.IsAdmin,
            };
            //check to see if theyre already in the database
            Employee? first = _context.Employees.FirstOrDefault(e => employee.Email.Equals(e.Email) && e.Password==null);
            if (first != null)
            {
                //only runs if first doesnt contain nothing (employee emails must already exist in the db)
                //sets the fields in the db
                first.Password = employee.Password;
                first.Role= employee.Role;
                first.IsAdmin= employee.IsAdmin;
                _context.Entry(first).State = EntityState.Modified;
            }
            //this will ensure that if a change is made to the database the insert method returns true
            return _context.SaveChanges() > 0;
        }
    }
}
