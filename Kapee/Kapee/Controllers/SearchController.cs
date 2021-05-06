using Kapee.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Kapee.Controllers
{
    public class SearchController : Controller
    {
        private readonly AplicationDbContext _context;
        public SearchController(AplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Search(string search)
        {
            var product = _context.Products
                                           .Where(x=>x.Name.ToLower()
                                           .Contains(search.ToLower()))
                                           .FirstOrDefault();


            if (product == null) return NotFound();

            return RedirectToAction("Index", "Product", new { id = product.Id });
        }
    }
}
