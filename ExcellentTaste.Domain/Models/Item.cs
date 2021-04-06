using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExcellentTaste.Domain
{
    public class Item
    {
        private const string errorMessageWrongPriceNotation = "price must be noted in a form like 123.45";

        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{1,16}([,.][0-9]{0,2})?$", ErrorMessage = errorMessageWrongPriceNotation)]
        public float Price { get; set; }
        [Required]
        public int BtwTypeId { get; set; }
        [Required]
        public int CatagoryId { get; set; }
        [Required]
        public bool Available { get; set; }
    }
}
