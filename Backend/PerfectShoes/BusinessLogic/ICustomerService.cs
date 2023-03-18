using PerfectShoes.Models;

namespace PerfectShoes.BusinessLogic
{
    public interface ICustomerService
    {
       Customer? GetCustomerById(int Id);
       bool UpdateCustomer(Customer customer);
    }
}
