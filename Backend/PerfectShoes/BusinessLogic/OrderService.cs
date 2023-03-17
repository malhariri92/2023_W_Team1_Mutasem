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
        public int InsertOrder(OrderDto dto)
        {
            Order order = new Order()
            {
                Customer = dto.Customer,
                CustomerName = dto.Customer.FirstName + " " + dto.Customer.LastName,
                CustomerEmail = dto.Customer.Email,
                ShippingAddress = dto.Customer.Address.ToString(),
                CreditCard = dto.Customer.CreditCard,
                Status = "received",
                Date = DateTime.Now,
                LineItems = dto.LineItems,
                Subtotal= dto.Subtotal,
                Tax = dto.Tax,
                Total = dto.Total,
            };
            Customer? customer = order.Customer;

            if (customer.Id == 0)
            {
                _context.Entry(order.CreditCard).State = EntityState.Added;
                order.CreditCardId = order.CreditCard.Id;
            }
            
            _context.Entry(order).State = EntityState.Added;

            foreach (LineItem item in order.LineItems)
            {
                item.OrderId = order.Id;
                _context.Entry(item).State = EntityState.Added;
            }

            return _context.SaveChanges() > 0 ? order.Id : 0;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.Where(p => p.Status == "received")
                 .OrderBy(x => x.Date).ToList();
        }
    }
}