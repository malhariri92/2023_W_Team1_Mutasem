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
        public ActionResult InsertOrder(Order order)
        {
            if (_orderService.InsertOrder(order)) return Ok();
            return BadRequest();
        }
        
    }
}
