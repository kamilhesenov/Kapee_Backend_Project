using Kapee.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Areas.UserPanel.Controllers.Product
{
    [Area("UserPanel")]
    public class ProductPrizeController : Controller
    {
        private readonly AplicationDbContext _context;
        public ProductPrizeController(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var prize = await _context.ProductPrizes.Include(x => x.Product).ToListAsync();

            return View(prize);
        }
    }
}
