using Kapee.Models.Header_Footer;
using System.Collections.Generic;

namespace Kapee.Models.ViewModel
{
    public class HeaderViewModel
    {
        public HeaderLogo HeaderLogo { get; set; }
        public List<Category.Category> Categories { get; set; }
        public List<Product.Product> Products { get; set; }
    }
}
