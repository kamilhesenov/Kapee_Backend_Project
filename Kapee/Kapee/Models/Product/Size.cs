using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Models.Product
{
    public class Size
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Key { get; set; }

        [Required, MaxLength(250)]
        public string Value { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
    }
}
