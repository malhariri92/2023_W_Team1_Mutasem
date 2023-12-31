﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectShoes.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime Date { get; set; }

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
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAddress { get; set; }
        public int CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }   
    }
}
