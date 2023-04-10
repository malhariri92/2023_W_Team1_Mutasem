using Microsoft.AspNetCore.Mvc;
using PerfectShoes.BusinessLogic;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;


namespace PerfectShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController:  ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Update to use order dto when created.
        
        [HttpPost(Name = "InsertOrder")]
        public ActionResult InsertOrder(OrderDto orderDto)
        {
            Order order = _orderService.InsertOrder(orderDto);
            if (order != null) return Ok(order);
            return BadRequest();
        }

        [HttpGet(Name = "GetOrder")]
        public ActionResult<List<Order>> Get()
        {
            var orders = _orderService.GetAllOrders();

            if (orders == null) return NotFound();

            return Ok(orders);
        }

        [HttpPost("Fulfill", Name = "FulfillOrder")]
        public ActionResult FulfillOrder(Order order)
        {
            if(_orderService.FulfillOder(order)) return Ok();
            return BadRequest();
        }
        /*
        [HttpGet(Name = "GetOrderById")]
        public ActionResult<Order> Get(int id)
        {
            Order? order = _orderService.GetOrderbyId(id);
            if (order == null) return NotFound();
            return Ok(order);
        }*/
    }

}

