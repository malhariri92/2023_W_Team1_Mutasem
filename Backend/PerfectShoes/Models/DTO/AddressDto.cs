using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models.DTO
{
    public class AddressDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Address Line 1 is Required")]
        public string AddressLine1 { get; set; }

        
        [Required(ErrorMessage = "Zip Code is Required")]
        public string Zip { get; set; }

       
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

    
        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }

        public string AddressLine2 { get; set; }
    } 
}
