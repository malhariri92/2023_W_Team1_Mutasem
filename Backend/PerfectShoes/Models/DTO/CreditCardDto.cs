using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models.DTO
{
    public class CreditCardDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [StringLength(50)]
        public string NameOnCard { get; set; }

        [StringLength(18)]
        public string CardNumber { get; set; }

        [StringLength(3)]
        public string cvc { get; set; }

        public DateTime ExprDate { get; set; }
    }
}
