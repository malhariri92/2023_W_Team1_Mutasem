using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models
{
    public class Address
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [StringLength(5)]
        public string Zip { get; set; }

        public override string? ToString()
        {
            return AddressLine1 + " " + AddressLine2 + "\n" + City + ", " + State + " " + Zip;
        }
    }
}
