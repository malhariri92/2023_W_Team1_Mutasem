using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models
{
    public class Specification
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}