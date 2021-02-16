using System.ComponentModel.DataAnnotations;


namespace Kapee.Models.Home
{
    public class ProductGallery
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public string Photo { get; set; }

        [MaxLength(100)]
        public string Link { get; set; }
        public Product Product { get; set; }
    }
}
