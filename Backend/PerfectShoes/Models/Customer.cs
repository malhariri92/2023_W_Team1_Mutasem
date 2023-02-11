namespace PerfectShoes.Models
{
    public class Customer : User
    {
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public int? CreditCardId { get; set; }
        public CreditCard? CreditCard { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
