using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models
{
    public class Employee : User
    {

        [StringLength(50)]
        public string Role { get; set; }
        public bool IsAdmin { get; set; }

    }
}
