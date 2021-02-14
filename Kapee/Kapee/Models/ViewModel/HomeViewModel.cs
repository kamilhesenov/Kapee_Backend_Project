using Kapee.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Models.ViewModel
{
    public class HomeViewModel
    {
        public List<CategoryCarusel> CategoryCarusels { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Info> Infos { get; set; }
        public List<CategoryCallection> CategoryCallections { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public TestimonialItem TestimonialItem { get; set; }
    }
}
