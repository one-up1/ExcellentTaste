using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExcellentTaste.Domain.Models
{
    public class Filling
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public int DurationMinutes { get; set; }
        [Required]
        public int BufferMinutes { get; set; }
    }
}
