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
        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
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
            return Ok(_creditCardService.UpsertCreditCard(dto));
        }
    }
}
