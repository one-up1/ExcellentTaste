using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExcellentTaste.Domain
{
    public class Waiter
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public int Name { get; set; }
    }
}
