using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kapee.Models.Product
{
    public class ProductPrize
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required, Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "${0:#.00}")]
        public decimal Prize { get; set; }
        public Product Product { get; set; }
    }
}
