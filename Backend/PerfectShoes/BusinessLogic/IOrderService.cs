using PerfectShoes.Models;
using PerfectShoes.Models.DTO;


namespace PerfectShoes.BusinessLogic
{
    public interface IOrderService
    {
        // Update to OrderDTO when the DTO is created
        bool InsertOrder(Order order);
    }
}
