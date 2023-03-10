using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models.DTO
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email name is required")]
        public string Email { get; set; }
        public string? Password { get; set; }

        public string Type { get; set; }
    }
}
