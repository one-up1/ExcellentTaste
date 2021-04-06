using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcellentTaste.Domain
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [ForeignKey("Table")]
        [Required]
        public int TableId { get; set; }
        [ForeignKey("Waiter")]
        [Required]
        public int WaitorId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [ForeignKey("Filling")]
        [Required]
        public int FillingId { get; set; }
        [Required]
        public bool Completed { get; set; }
    }
}
