namespace PerfectShoes.Models.DTO
{
    public class CustomerDto : UserDto
    {
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
        public List<Order> Orders { get; set; }
    }
}
