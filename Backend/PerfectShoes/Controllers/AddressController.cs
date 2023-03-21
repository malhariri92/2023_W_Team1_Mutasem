using Microsoft.AspNetCore.Mvc;
using PerfectShoes.BusinessLogic;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost(Name = "AddAddress")]
        public ActionResult AddAddress(AddressDto dto)
        {
            Address address = _addressService.AddAddress(dto);
            if (address != null) return Ok(address);
            return BadRequest();
        }

        [HttpPost("update", Name = "UpdateAddress")]
        public ActionResult UpdateAddress(AddressDto dto)
        {
            Address address = _addressService.UpdateAddress(dto);
            if (address != null) return Ok(address);
            return BadRequest();
        }

    }
}
