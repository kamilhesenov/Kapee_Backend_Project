using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kapee.Models.Product
{
    public class Color
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Key { get; set; }

        [Required, MaxLength(250)]
        public string Value { get; set; }
        public List<ProductColor> ProductColors { get; set; }
    }
}
