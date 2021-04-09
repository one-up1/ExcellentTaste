using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcellentTaste.Domain.Models
{
    public class OrderItem
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Item")]
        [Required]
        public int OrderId { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Item")]
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public bool Prepared { get; set; }
        [Required]
        public bool Delivered { get; set; }
    }
}
