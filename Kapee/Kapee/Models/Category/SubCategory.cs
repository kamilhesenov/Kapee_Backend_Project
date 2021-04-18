using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kapee.Models.Product;


namespace Kapee.Models.Category
{
    public class SubCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }
        public Category Category { get; set; }
        public List<Product.Product> Products { get; set; }
    }
}
