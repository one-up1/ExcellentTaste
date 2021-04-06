using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExcellentTaste.Domain
{
    public class OrderItem
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public bool Prepared { get; set; }
        [Required]
        public bool Delivered { get; set; }
    }
}
