using Microsoft.EntityFrameworkCore;
using PerfectShoes.Models;

namespace PerfectShoes.BusinessLogic
{
    public class CustomerService : Service, ICustomerService
    {
        public CustomerService(DataContext context) : base(context) { }
        public User? GetCustomerById(int Id)
        {
            var user = _context.Users.Find(Id);
            return user;
        }
    }
}
