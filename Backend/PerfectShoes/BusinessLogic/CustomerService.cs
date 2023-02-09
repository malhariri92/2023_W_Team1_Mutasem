using Microsoft.EntityFrameworkCore;
using PerfectShoes.Models;

namespace PerfectShoes.BusinessLogic
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;
        public CustomerService(DataContext context)
        {
            _context = context;
        }
        public Customer? GetCustomerById(int Id)
        {
            var customer = _context.Customers.Include(c => c.Address)
                .Include(c => c.CreditCard)
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.Id == Id);
            return customer;
        }
    }
}
