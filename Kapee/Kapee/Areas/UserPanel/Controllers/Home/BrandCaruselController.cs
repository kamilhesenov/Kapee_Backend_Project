using Kapee.Data;
using Kapee.Filter;
using Kapee.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Areas.UserPanel.Controllers.Home
{
    [Area("UserPanel")]
    public class BrandCaruselController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public BrandCaruselController(AplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public async Task<IActionResult> Index()
        {
            var brandCarusel = await _context.CategoryCarusels.ToListAsync();

            return View(brandCarusel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var brandCarusel = await _context.CategoryCarusels.FirstOrDefaultAsync(x => x.Id == id);
            if (brandCarusel == null) return NotFound();

            return View(brandCarusel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Upload,Photo,Id")] CategoryCarusel brandCarusel)
        {
            if (brandCarusel.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }
            else
            {
                if (brandCarusel.Upload.ContentType != "image/jpeg" && brandCarusel.Upload.ContentType != "image/png" && brandCarusel.Upload.ContentType != "image/gif")
                {
                    ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                }

                if (brandCarusel.Upload.Length > 1048576)
                {
                    ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                }

            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(brandCarusel.Upload);
                brandCarusel.Photo = fileName;

                _context.Add(brandCarusel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brandCarusel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var brandCarusel = await _context.CategoryCarusels.FirstOrDefaultAsync(x => x.Id == id);
            if (brandCarusel == null) return NotFound();

            return View(brandCarusel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Upload,Photo,Id")] CategoryCarusel brandCarusel)
        {
            if (id != brandCarusel.Id) return NotFound();

            if (brandCarusel.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }

            if (ModelState.IsValid)
            {

                try
                {
                    if (brandCarusel.Upload != null)
                    {
                        if (brandCarusel.Upload.ContentType != "image/jpeg" && brandCarusel.Upload.ContentType != "image/png" && brandCarusel.Upload.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                            return View(brandCarusel);
                        }

                        if (brandCarusel.Upload.Length > 1048576)
                        {
                            ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                            return View(brandCarusel);
                        }

                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", brandCarusel.Photo);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(brandCarusel.Upload, "wwwroot/uploads");
                        brandCarusel.Photo = fileName;
                    }

                    _context.Update(brandCarusel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandCaruselExsist(brandCarusel.Id))
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
            return View(brandCarusel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var brandCarusel = await _context.CategoryCarusels.FirstOrDefaultAsync(x => x.Id == id);
            if (brandCarusel == null) return NotFound();

            return View(brandCarusel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var brandCarusel = await _context.CategoryCarusels.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", brandCarusel.Photo);
                _fileManager.Delete(oldFile, "wwwroot/uploads");
            }
            catch (FileNotFoundException)
            {
                _context.CategoryCarusels.Remove(brandCarusel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _context.CategoryCarusels.Remove(brandCarusel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandCaruselExsist(int id)
        {
            return _context.CategoryCarusels.Any(x => x.Id == id);
        }
    }
}
