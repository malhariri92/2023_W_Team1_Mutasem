using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public interface ICreditCardService
    {
        public CreditCard? GetCreditCardById(int Id);

        public CreditCard UpsertCreditCard(CreditCardDto dto);
    }
}
