using Kapee.Data;
using Kapee.Filter;
using Kapee.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Areas.UserPanel.Controllers.Product
{
    [Area("UserPanel")]
    public class ProductGalleriesController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public ProductGalleriesController(AplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public async Task<IActionResult> Index()
        {
            var productGalery = await _context.ProductGalleries.Include(x => x.Product).OrderByDescending(x => x.Id).ToListAsync();

            return View(productGalery);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var productGalery = await _context.ProductGalleries.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
            if (productGalery == null) return NotFound();

            return View(productGalery);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Upload,Photo,ProductId,Link")] ProductGallery productGalery)
        {
            if (productGalery.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }
            else
            {
                if (productGalery.Upload.ContentType != "image/jpeg" && productGalery.Upload.ContentType != "image/png" && productGalery.Upload.ContentType != "image/gif")
                {
                    ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                }

                if (productGalery.Upload.Length > 1048576)
                {
                    ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                }

            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(productGalery.Upload);
                productGalery.Photo = fileName;

                _context.Add(productGalery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productGalery.ProductId);

            return View(productGalery);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var productGalery = await _context.ProductGalleries.FirstOrDefaultAsync(x => x.Id == id);
            if (productGalery == null) return NotFound();

            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productGalery.ProductId);

            return View(productGalery);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Upload,Photo,ProductId,Link")] ProductGallery productGalery)
        {
            if (id != productGalery.Id) return NotFound();

            if (productGalery.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }

            if (ModelState.IsValid)
            {

                try
                {
                    if (productGalery.Upload != null)
                    {
                        if (productGalery.Upload.ContentType != "image/jpeg" && productGalery.Upload.ContentType != "image/png" && productGalery.Upload.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                            return View(productGalery);
                        }

                        if (productGalery.Upload.Length > 1048576)
                        {
                            ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                            return View(productGalery);
                        }

                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", productGalery.Photo);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(productGalery.Upload, "wwwroot/uploads");
                        productGalery.Photo = fileName;
                    }

                    _context.Update(productGalery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductGaleryExsist(productGalery.Id))
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

            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productGalery.ProductId);

            return View(productGalery);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var productGalery = await _context.ProductGalleries.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
            if (productGalery == null) return NotFound();

            return View(productGalery);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var productGalery = await _context.ProductGalleries.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", productGalery.Photo);
                _fileManager.Delete(oldFile, "wwwroot/uploads");
            }
            catch (FileNotFoundException)
            {
                _context.ProductGalleries.Remove(productGalery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _context.ProductGalleries.Remove(productGalery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductGaleryExsist(int id)
        {
            return _context.ProductGalleries.Any(x => x.Id == id);
        }
    }
}
