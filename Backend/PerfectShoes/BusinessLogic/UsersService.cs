using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;
using System.Collections.Generic;

namespace PerfectShoes.BusinessLogic
{
    public class UsersService : Service, IUsersService
    {
        public UsersService(DataContext context) : base(context) { }

        public User? Authenticate(AuthentificationDto authentificationDto)
        {
            return _context.Users.FirstOrDefault(e => authentificationDto.Email.Equals(e.Email) && authentificationDto.Password.Equals(e.Password));
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
                Type = userDto.Type,
            };
            //check to see if theyre already in the database
            if (user.Type == "employee")
                InsertEmployee(user);
            else if (user.Type == "customer")
                InsertCustomer(user);
            
            //this will ensure that if a change is made to the database the insert method returns true
            return _context.SaveChanges() > 0;
        }
        private bool InsertEmployee(User user)
        {
            bool valid=false;
            Employee? first = (Employee?)_context.Users.FirstOrDefault(e=> user.Email.Equals(e.Email) && e.Password==null);
            if (first != null)
            {
                first.FirstName=user.FirstName;
                first.LastName=user.LastName;
                first.Password=user.Password;
                first.Type = user.Type;
                first.Role = "admin";
                first.IsAdmin= true;
                valid = true;
                _context.Entry(first).State= EntityState.Modified;
            }
            return valid;
        }//end of InsertEmployee method

        private bool InsertCustomer(User user)
        {
            bool valid = false;
            Customer? first = (Customer?)_context.Users.FirstOrDefault(e => user.Email.Equals(e.Email));
            if (first == null)
            {
                _context.Users.Add(user);
                valid = true;
            }
            else if(first.Password == null)
            {
                first.FirstName = user.FirstName;
                first.LastName = user.LastName;
                first.Password = user.Password;
                first.Type = user.Type;
                valid = true;
                _context.Entry(first).State= EntityState.Modified;
            }
            return valid;
        }//end of InsertCustomer method
    }
}
