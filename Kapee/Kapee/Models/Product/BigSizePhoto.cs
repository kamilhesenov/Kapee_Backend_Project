using System.ComponentModel.DataAnnotations;


namespace Kapee.Models.Product
{
    public class BigSizePhoto
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public string Photo { get; set; }
        public Product Product { get; set; }
    }
}
