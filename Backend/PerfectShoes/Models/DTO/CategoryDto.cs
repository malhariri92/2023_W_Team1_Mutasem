using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models.DTO
{
    public class CategoryDto
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}
