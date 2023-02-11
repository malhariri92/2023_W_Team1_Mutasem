using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NameOnCard { get; set; }

        [StringLength(18)]
        public string CardNumber { get; set; }

        [StringLength(3)]
        public string CSV { get; set; }
        public DateTime ExprDate { get; set; }
    }
}
