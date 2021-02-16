using Kapee.Models;
using Kapee.Models.Header_Footer;
using Kapee.Models.Home;
using Microsoft.EntityFrameworkCore;

namespace Kapee.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext>options):base(options)
        {

        }

        public DbSet<CategoryCarusel> CategoryCarusels { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<CategoryCallection> CategoryCallections { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<TestimonialItem> TestimonialItems { get; set; }
        public DbSet<FashionSlider> FashionSliders { get; set; }
        public DbSet<News> Newses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HeaderLogo> HeaderLogos { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<FooterLogo> FooterLogos { get; set; }
        public DbSet<Vender> Venders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeatured> ProductFeatureds { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }

    }
}
