using Kapee.Data;
using Kapee.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Areas.UserPanel.Controllers.Category
{
    [Area("UserPanel")]
    public class SubCategoriesController : Controller
    {
        private readonly AplicationDbContext _context;
        public SubCategoriesController(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var subcategory = await _context.SubCategories.Include(x=>x.Category).ToListAsync();

            return View(subcategory);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var subcategory = await _context.SubCategories.Include(x=>x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (subcategory == null) return NotFound();

            return View(subcategory);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subCategory);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", subCategory.CategoryId);

            return View(subCategory);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var subCategory = await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (subCategory == null) return NotFound();

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", subCategory.CategoryId);

            return View(subCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,CategoryId")] SubCategory subCategory)
        {
            if (id != subCategory.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategoryExists(subCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", subCategory.CategoryId);

            return View(subCategory);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var subcategory = await _context.SubCategories.Include(x=>x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (subcategory == null) return NotFound();

            return View(subcategory);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var subcategory = await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
            _context.SubCategories.Remove(subcategory);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool SubCategoryExists(int id)
        {
            return _context.SubCategories.Any(x => x.Id == id);
        }
    }
}
