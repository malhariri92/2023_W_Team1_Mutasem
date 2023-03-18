using Microsoft.AspNetCore.Mvc;
using PerfectShoes.BusinessLogic;
using PerfectShoes.Models.DTO;
using PerfectShoes.Models;

namespace PerfectShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;
        private readonly ICustomerService _customerService;

        public CreditCardController(ICreditCardService creditCardService, ICustomerService customerService)
        {
            _creditCardService = creditCardService;
            _customerService = customerService;
        }

        [HttpGet(Name = "Get")]
        public ActionResult<CreditCard> Get(int id)
        {
            CreditCard? creditCard = _creditCardService.GetCreditCardById(id);
            if (creditCard == null) return NotFound();
            return Ok(creditCard);
        }

        [HttpPost(Name = "Upsert")]
        public ActionResult<CreditCard> Upsert(CreditCardDto dto)
        {
            Customer? customer = _customerService.GetCustomerById(dto.CustomerId);
            if (customer == null) return NotFound();

            CreditCard card = _creditCardService.UpsertCreditCard(dto);
            customer.CreditCardId = card.Id;
            _customerService.UpdateCustomer(customer);

            return Ok(card);
        }
    }
}
