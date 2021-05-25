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
    public class BigSizePhotoesController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public BigSizePhotoesController(AplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public async Task<IActionResult> Index()
        {
            var bigsizePhoto = await _context.BigSizePhotos.Include(x=>x.Product).OrderByDescending(x=>x.Id).ToListAsync();

            return View(bigsizePhoto);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var bigsizePhoto = await _context.BigSizePhotos.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
            if (bigsizePhoto == null) return NotFound();

            return View(bigsizePhoto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Upload,Photo,ProductId")] BigSizePhoto bigsizePhoto)
        {
            if (bigsizePhoto.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }
            else
            {
                if (bigsizePhoto.Upload.ContentType != "image/jpeg" && bigsizePhoto.Upload.ContentType != "image/png" && bigsizePhoto.Upload.ContentType != "image/gif")
                {
                    ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                }

                if (bigsizePhoto.Upload.Length > 1048576)
                {
                    ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                }

            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(bigsizePhoto.Upload);
                bigsizePhoto.Photo = fileName;

                _context.Add(bigsizePhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", bigsizePhoto.ProductId);
            
            return View(bigsizePhoto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var bigsizePhoto = await _context.BigSizePhotos.FirstOrDefaultAsync(x => x.Id == id);
            if (bigsizePhoto == null) return NotFound();

            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", bigsizePhoto.ProductId);

            return View(bigsizePhoto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Upload,Photo,ProductId")] BigSizePhoto bigsizePhoto)
        {
            if (id != bigsizePhoto.Id) return NotFound();

            if (bigsizePhoto.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }

            if (ModelState.IsValid)
            {

                try
                {
                    if (bigsizePhoto.Upload != null)
                    {
                        if (bigsizePhoto.Upload.ContentType != "image/jpeg" && bigsizePhoto.Upload.ContentType != "image/png" && bigsizePhoto.Upload.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                            return View(bigsizePhoto);
                        }

                        if (bigsizePhoto.Upload.Length > 1048576)
                        {
                            ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                            return View(bigsizePhoto);
                        }

                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", bigsizePhoto.Photo);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(bigsizePhoto.Upload, "wwwroot/uploads");
                        bigsizePhoto.Photo = fileName;
                    }

                    _context.Update(bigsizePhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BigsizePhotoExsist(bigsizePhoto.Id))
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

            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", bigsizePhoto.ProductId);

            return View(bigsizePhoto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var bigsizePhoto = await _context.BigSizePhotos.Include(x=>x.Product).FirstOrDefaultAsync(x => x.Id == id);
            if (bigsizePhoto == null) return NotFound();

            return View(bigsizePhoto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var bigsizePhoto = await _context.BigSizePhotos.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", bigsizePhoto.Photo);
                _fileManager.Delete(oldFile, "wwwroot/uploads");
            }
            catch (FileNotFoundException)
            {
                _context.BigSizePhotos.Remove(bigsizePhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _context.BigSizePhotos.Remove(bigsizePhoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BigsizePhotoExsist(int id)
        {
            return _context.BigSizePhotos.Any(x => x.Id == id);
        }
    }
}
