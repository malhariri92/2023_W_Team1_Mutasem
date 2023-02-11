using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
