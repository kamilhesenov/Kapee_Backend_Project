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
    public class CollectionController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public CollectionController(AplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public async Task<IActionResult> Index()
        {
            var collection = await _context.CategoryCallections.ToListAsync();

            return View(collection);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var collection = await _context.CategoryCallections.FirstOrDefaultAsync(x => x.Id == id);
            if (collection == null) return NotFound();

            return View(collection);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Upload,Photo,Id,Content")] CategoryCallection collection)
        {
            if (collection.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }
            else
            {
                if (collection.Upload.ContentType != "image/jpeg" && collection.Upload.ContentType != "image/png" && collection.Upload.ContentType != "image/gif")
                {
                    ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                }

                if (collection.Upload.Length > 1048576)
                {
                    ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                }

            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(collection.Upload);
                collection.Photo = fileName;

                _context.Add(collection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(collection);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var collection = await _context.CategoryCallections.FirstOrDefaultAsync(x => x.Id == id);
            if (collection == null) return NotFound();

            return View(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Upload,Photo,Id,Content")] CategoryCallection collection)
        {
            if (id != collection.Id) return NotFound();

            if (collection.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }

            if (ModelState.IsValid)
            {

                try
                {
                    if (collection.Upload != null)
                    {
                        if (collection.Upload.ContentType != "image/jpeg" && collection.Upload.ContentType != "image/png" && collection.Upload.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                            return View(collection);
                        }

                        if (collection.Upload.Length > 1048576)
                        {
                            ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                            return View(collection);
                        }

                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", collection.Photo);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(collection.Upload, "wwwroot/uploads");
                        collection.Photo = fileName;
                    }

                    _context.Update(collection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectionExsist(collection.Id))
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
            return View(collection);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var collection = await _context.CategoryCallections.FirstOrDefaultAsync(x => x.Id == id);
            if (collection == null) return NotFound();

            return View(collection);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var collection = await _context.CategoryCallections.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", collection.Photo);
                _fileManager.Delete(oldFile, "wwwroot/uploads");
            }
            catch (FileNotFoundException)
            {
                _context.CategoryCallections.Remove(collection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _context.CategoryCallections.Remove(collection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectionExsist(int id)
        {
            return _context.CategoryCallections.Any(x => x.Id == id);
        }
    }
}
