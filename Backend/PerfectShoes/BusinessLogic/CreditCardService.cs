using Microsoft.EntityFrameworkCore;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;
using System.Diagnostics.Metrics;

namespace PerfectShoes.BusinessLogic
{
    public class CreditCardService : Service, ICreditCardService
    {
        public CreditCardService(DataContext context) : base(context) { }
        public CreditCard? GetCreditCardById(int Id)
        {
            return _context.CreditCards.Find(Id);
        }

        public CreditCard UpsertCreditCard(CreditCardDto dto)
        {
            string[] dateSeparated = dto.ExprDate.Split('/');
            CreditCard card = new CreditCard()
            {
                CardNumber = dto.CardNumber,
                CVC = dto.cvc,
                NameOnCard = dto.NameOnCard,
                ExprDate = new DateTime(int.Parse("20" + dateSeparated[1]), int.Parse(dateSeparated[0]), 1),
            };

            if (dto.Id != null)
            {
                card.Id = dto.Id.Value;
                _context.CreditCards.Update(card);
                _context.SaveChanges();
            }
            else
            {
                _context.CreditCards.Add(card);
            }

            return card;
        }
    }
}
