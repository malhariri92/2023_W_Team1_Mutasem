using Microsoft.EntityFrameworkCore;
using PerfectShoes.Models;

namespace PerfectShoes.BusinessLogic
{
    public class CustomerService : Service, ICustomerService
    {
        public CustomerService(DataContext context) : base(context) { }
        public Customer? GetCustomerById(int Id)
        {
            return _context.Customers.Find(Id);
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            return _context.SaveChanges() > 0;
        }
    }
}
