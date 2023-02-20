using Microsoft.AspNetCore.Mvc;
using PerfectShoes.BusinessLogic;
using PerfectShoes.Models;

namespace PerfectShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet(Name = "AuthenticateAsEmployee")]
        public ActionResult<Employee> AuthenticateAsEmployee(string email, string password)
        {
            Employee? employee = _employeeService.AuthenticateAsEmployee(email, password);

            if (employee == null) return NotFound();

            return Ok(employee);
        }
    }
}
