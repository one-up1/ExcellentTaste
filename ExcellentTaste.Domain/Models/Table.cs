using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExcellentTaste.Domain.Models
{
    public class Table
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
