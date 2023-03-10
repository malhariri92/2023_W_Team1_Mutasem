using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(320)]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 8)]
        public string? Password { get; set; }

        public string Type { get; set; }
    }
}
