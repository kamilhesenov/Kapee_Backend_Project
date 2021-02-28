using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kapee.Models.Home
{
    public class Brand
    {
        public int Id { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
        public List<Product.Product> Products { get; set; }
    }
}
