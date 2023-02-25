using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace PerfectShoes.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }       
        public string ImageUrl { get; set; }
        public List<Specification>? Specs { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
    }
}
