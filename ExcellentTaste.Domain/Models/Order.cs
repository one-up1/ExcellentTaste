using System;
using System.ComponentModel.DataAnnotations;

namespace ExcellentTaste.Domain
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TableId { get; set; }
        [Required]
        public int WaitorId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public int FillingId { get; set; }
        [Required]
        public bool Completed { get; set; }
    }
}
