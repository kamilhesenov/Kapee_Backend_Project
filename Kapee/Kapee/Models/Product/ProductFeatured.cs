using System.ComponentModel.DataAnnotations;


namespace Kapee.Models.Product
{
    public class ProductFeatured
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required, MaxLength(100)]
        public string Key { get; set; }

        [Required, MaxLength(200)]
        public string Value { get; set; }

        public bool IsCoolor { get; set; }
        public bool IsSize { get; set; }
        public Product Product { get; set; }
    }
}
