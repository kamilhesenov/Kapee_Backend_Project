using System.ComponentModel.DataAnnotations.Schema;


namespace Kapee.Models
{
    public class ProductCheckout
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CheckoutId { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int Count { get; set; }
        public Product.Product Product { get; set; }
        public Checkout Checkout { get; set; }
    }
}
