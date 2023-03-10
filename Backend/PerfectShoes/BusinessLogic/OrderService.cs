using Microsoft.EntityFrameworkCore;
using PerfectShoes.BusinessLogic;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public class OrderService : Service, IOrderService
    {
        public OrderService(DataContext context) : base(context) { }

        // Update to use OrderDTO in future
        public bool InsertOrder(Order order)
        {
            var ord = new Order
            {
                Customer = order.Customer,
                Subtotal = order.Subtotal,
                Tax = order.Tax,
                Total= order.Total,
                LineItems = order.LineItems
            };
            _context.Orders.Add(ord);
            return _context.SaveChanges() > 0;
        }
    }
}