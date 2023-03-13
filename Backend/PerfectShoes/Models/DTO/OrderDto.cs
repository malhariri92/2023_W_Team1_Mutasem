using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PerfectShoes.Models.DTO
{
    public class OrderDto
    {
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
        public DateTime? ShipDate { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}
