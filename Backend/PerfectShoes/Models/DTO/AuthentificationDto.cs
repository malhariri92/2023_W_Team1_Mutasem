using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models.DTO
{
    public class AuthentificationDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
