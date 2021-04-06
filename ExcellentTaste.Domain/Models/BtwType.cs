using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExcellentTaste.Domain
{
    public class BtwType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Percentage { get; set; }
    }
}
