using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;


namespace Kapee.Models.ViewModel
{
    public class CategoryViewModel
    {
        public Category.Category Category { get; set; }
        public List<Product.Product> Products { get; set; }
        public List<Category.Category> Categories { get; set; }
        public PagingList<Product.Product> PagingList { get; set; }
        public List<Product.Color> Colors { get; set; }
        public List<Product.Size> Sizes { get; set; }
    }
}
