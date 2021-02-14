using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}
