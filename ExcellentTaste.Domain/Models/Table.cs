using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExcellentTaste.Domain
{
    public class Table
    {
        [Required]
        public int Id { get; set; }
    }
}
