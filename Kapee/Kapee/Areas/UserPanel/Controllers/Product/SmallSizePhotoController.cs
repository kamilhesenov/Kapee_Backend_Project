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
    public class SmallSizePhotoController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public SmallSizePhotoController(AplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public async Task<IActionResult> Index()
        {
            var smallsizePhoto = await _context.SmallSizePhotos.Include(x => x.Product).OrderByDescending(x => x.Id).ToListAsync();

            return View(smallsizePhoto);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var smallsizePhoto = await _context.SmallSizePhotos.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
            if (smallsizePhoto == null) return NotFound();

            return View(smallsizePhoto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Upload,Photo,ProductId")] SmallSizePhoto smallsizePhoto)
        {
            if (smallsizePhoto.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }
            else
            {
                if (smallsizePhoto.Upload.ContentType != "image/jpeg" && smallsizePhoto.Upload.ContentType != "image/png" && smallsizePhoto.Upload.ContentType != "image/gif")
                {
                    ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                }

                if (smallsizePhoto.Upload.Length > 1048576)
                {
                    ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                }

            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(smallsizePhoto.Upload);
                smallsizePhoto.Photo = fileName;

                _context.Add(smallsizePhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", smallsizePhoto.ProductId);

            return View(smallsizePhoto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var smallsizePhoto = await _context.SmallSizePhotos.FirstOrDefaultAsync(x => x.Id == id);
            if (smallsizePhoto == null) return NotFound();

            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", smallsizePhoto.ProductId);

            return View(smallsizePhoto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Upload,Photo,ProductId")] SmallSizePhoto smallsizePhoto)
        {
            if (id != smallsizePhoto.Id) return NotFound();

            if (smallsizePhoto.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }

            if (ModelState.IsValid)
            {

                try
                {
                    if (smallsizePhoto.Upload != null)
                    {
                        if (smallsizePhoto.Upload.ContentType != "image/jpeg" && smallsizePhoto.Upload.ContentType != "image/png" && smallsizePhoto.Upload.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                            return View(smallsizePhoto);
                        }

                        if (smallsizePhoto.Upload.Length > 1048576)
                        {
                            ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                            return View(smallsizePhoto);
                        }

                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", smallsizePhoto.Photo);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(smallsizePhoto.Upload, "wwwroot/uploads");
                        smallsizePhoto.Photo = fileName;
                    }

                    _context.Update(smallsizePhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmallsizePhotoExsist(smallsizePhoto.Id))
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

            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", smallsizePhoto.ProductId);

            return View(smallsizePhoto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var smallsizePhoto = await _context.SmallSizePhotos.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
            if (smallsizePhoto == null) return NotFound();

            return View(smallsizePhoto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var smallsizePhoto = await _context.SmallSizePhotos.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", smallsizePhoto.Photo);
                _fileManager.Delete(oldFile, "wwwroot/uploads");
            }
            catch (FileNotFoundException)
            {
                _context.SmallSizePhotos.Remove(smallsizePhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _context.SmallSizePhotos.Remove(smallsizePhoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmallsizePhotoExsist(int id)
        {
            return _context.SmallSizePhotos.Any(x => x.Id == id);
        }
    }
}
