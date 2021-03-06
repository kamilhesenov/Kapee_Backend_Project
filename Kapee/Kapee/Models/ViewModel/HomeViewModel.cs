﻿using Kapee.Models.Home;
using System.Collections.Generic;


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
        public List<FashionSlider> FashionSliders { get; set; }
        public List<News> Newses { get; set; }
        public List<Category.Category> Categories { get; set; }
        public List<Product.Product> Products { get; set; }
        public int? Id { get; internal set; }
    }
}
