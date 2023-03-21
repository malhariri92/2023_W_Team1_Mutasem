using Microsoft.EntityFrameworkCore;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

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
            CreditCard card = new CreditCard()
            {
                Id = dto.Id,
                CardNumber = dto.CardNumber,
                CVC = dto.cvc,
                NameOnCard = dto.NameOnCard,
                ExprDate = dto.ExprDate,
            };
            Customer customer = _context.Customers.Find(dto.CustomerId);

            if (card.Id != 0)
            {
                Order? order = _context.Orders.FirstOrDefault(o => o.CreditCardId == card.Id);
                if (order == null)
                {
                    _context.Entry(card).State = EntityState.Modified;
                }
                else
                {
                    card.Id = 0;
                    _context.Entry(card).State = EntityState.Added;
                }
            }
            else
            {
                _context.Entry(card).State = EntityState.Added;
            }
            _context.SaveChanges();

            customer.CreditCardId = card.Id;
            _context.Entry(customer).State = EntityState.Modified;

            _context.SaveChanges();
            return card;
        }
    }
}
