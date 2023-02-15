using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<User> Get(int Id)
        {
            var user = _customerService.GetCustomerById(Id);

            if (user == null) return NotFound();

            return Ok(user);
        }
    }
}