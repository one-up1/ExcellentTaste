using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExcellentTaste.Domain.Models
{
    public class Catagory
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
