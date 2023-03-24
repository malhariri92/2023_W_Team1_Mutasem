using Microsoft.AspNetCore.Mvc;
using PerfectShoes.BusinessLogic;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpPost(Name = "Authenticate")]
        public ActionResult<User> Authenticate(AuthentificationDto authentificationDto)
        {
            User? user = _userService.Authenticate(authentificationDto);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost("Customer", Name ="InsertCustomer")]
        public ActionResult InsertEmployee(UserDto userDto)
        {
            if (_userService.InsertCustomer(userDto)) return Ok();
            return BadRequest();
        }

        [HttpPost("Employee", Name = "InsertEmployee")]
        public ActionResult InsertEmployee(EmployeeDto employeeDto)
        {
            if (_userService.InsertEmployee(employeeDto)) return Ok();
            return BadRequest();
        }
    }
}
