using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectShoes.BusinessLogic;
using PerfectShoes.Models;

namespace PerfectShoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {      
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _dataContext;
        private readonly ICustomerService _customerService;

        public WeatherForecastController(DataContext context, ILogger<WeatherForecastController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _dataContext = context;
            _customerService = customerService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<Customer> Get(int Id)
        {
            var customer = _customerService.GetCustomerById(Id);

            if (customer == null) return NotFound();

            return Ok(customer);
        }
    }
}