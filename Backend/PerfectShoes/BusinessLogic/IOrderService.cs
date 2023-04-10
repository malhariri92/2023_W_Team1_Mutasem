using PerfectShoes.Models;
using PerfectShoes.Models.DTO;


namespace PerfectShoes.BusinessLogic
{
    public interface IOrderService
    {
        // Update to OrderDTO when the DTO is created
        Order InsertOrder(OrderDto orderDto);
        List<Order> GetAllOrders();

        bool FulfillOder(Order order);

        Order? GetOrderbyId(int id);
    }
}
