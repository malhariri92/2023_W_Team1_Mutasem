using Microsoft.AspNetCore.Mvc;
using PerfectShoes.BusinessLogic;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;


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

        [HttpPost("User", Name = "InsertUser")]
        public ActionResult InsertUser(UserDto userDto)
        {
            if (_userService.InsertUser(userDto)) return Ok();
            return BadRequest();
        }


        [HttpPost("UpdatePassword", Name = "UpdatePassword")]
        public ActionResult UpdatePassword(UserDto userDto)
        {
            if (_userService.UpdatePassword(userDto)) return Ok();
            return BadRequest();
        }


        [HttpPost("Employee", Name = "AddEmployee")]
        public ActionResult AddEmployee(EmployeeDto employeeDto)
        {
            if (_userService.AddEmployee(employeeDto)) return Ok();
            return BadRequest();
        }
    }
}