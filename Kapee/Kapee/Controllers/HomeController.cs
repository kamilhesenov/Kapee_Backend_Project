using Kapee.Data;
using Kapee.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;


namespace Kapee.Controllers
{
    public class HomeController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,AplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                CategoryCarusels = _context.CategoryCarusels.ToList(),
                Brands = _context.Brands.ToList(),
                Infos = _context.Infos.ToList(),
                CategoryCallections = _context.CategoryCallections.ToList(),
                TestimonialItem = _context.TestimonialItems.FirstOrDefault(),
                Testimonials = _context.Testimonials.ToList(),
                FashionSliders = _context.FashionSliders.ToList(),
                Newses = _context.Newses.ToList(),
                Categories = _context.Categories.ToList(),
                Products = _context.Products.Include(x=>x.ProductGalleries)
                                            .Include(x=>x.Category)
                                            .ThenInclude(x=>x.SubCategories)
                                            .Include(x=>x.ProductColors)
                                            .ThenInclude(x=>x.Color)
                                            .Include(x=>x.ProductSizes)
                                            .ThenInclude(x=>x.Size).ToList()
            };

            return View(model);
        }
       
    }
}
