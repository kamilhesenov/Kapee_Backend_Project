using System.ComponentModel.DataAnnotations;


namespace Kapee.Models.Category
{
    public class SubCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int? ProductId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public Category Category { get; set; }
        public Product.Product Product { get; set; }
    }
}
