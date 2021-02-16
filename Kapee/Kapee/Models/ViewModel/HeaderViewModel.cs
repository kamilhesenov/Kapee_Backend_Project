using Kapee.Models.Header_Footer;
using Kapee.Models.Home;
using System.Collections.Generic;

namespace Kapee.Models.ViewModel
{
    public class HeaderViewModel
    {
        public HeaderLogo HeaderLogo { get; set; }
        public List<Category> Categories { get; set; }
    }
}
