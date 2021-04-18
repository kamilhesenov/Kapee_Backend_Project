using Kapee.Models.Product;
using System.Collections.Generic;

namespace Kapee.Models.ViewModel
{
    public class ProductViewModel
    {
        public Product.Product Product { get; set; }
        public List<Product.Product> Products { get; set; }
        public List<Product.Product> RecentlyViewedProducts { get; set; }

    }
}
