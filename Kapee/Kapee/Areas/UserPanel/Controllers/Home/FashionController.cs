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
    public class FashionController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public FashionController(AplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var fashion = await _context.FashionSliders.ToListAsync();

            return View(fashion);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var fashion = await _context.FashionSliders.FirstOrDefaultAsync(x => x.Id == id);
            if (fashion == null) return NotFound();

            return View(fashion);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Upload,Photo,Id,Content,Description,Link,TextStyleLeft,TextStyleRight,Status")] FashionSlider fashion)
        {
            if (fashion.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }
            else
            {
                if (fashion.Upload.ContentType != "image/jpeg" && fashion.Upload.ContentType != "image/png" && fashion.Upload.ContentType != "image/gif")
                {
                    ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                }

                if (fashion.Upload.Length > 1048576)
                {
                    ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                }

            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(fashion.Upload);
                fashion.Photo = fileName;

                _context.Add(fashion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fashion);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var fashion = await _context.FashionSliders.FirstOrDefaultAsync(x => x.Id == id);
            if (fashion == null) return NotFound();

            return View(fashion);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Upload,Photo,Id,Content,Description,Link,TextStyleLeft,TextStyleRight,Status")] FashionSlider fashion)
        {
            if (id != fashion.Id) return NotFound();

            if (fashion.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }

            if (ModelState.IsValid)
            {

                try
                {
                    if (fashion.Upload != null)
                    {
                        if (fashion.Upload.ContentType != "image/jpeg" && fashion.Upload.ContentType != "image/png" && fashion.Upload.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                            return View(fashion);
                        }

                        if (fashion.Upload.Length > 1048576)
                        {
                            ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                            return View(fashion);
                        }

                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fashion.Photo);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(fashion.Upload, "wwwroot/uploads");
                        fashion.Photo = fileName;
                    }

                    _context.Update(fashion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FashionExsist(fashion.Id))
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
            return View(fashion);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var fashion = await _context.FashionSliders.FirstOrDefaultAsync(x=>x.Id == id);
            if (fashion == null) return NotFound();

            return View(fashion);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var fashion = await _context.FashionSliders.FirstOrDefaultAsync(x=>x.Id == id);

            try
            {
                var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fashion.Photo);
                _fileManager.Delete(oldFile, "wwwroot/uploads");
            }
            catch (FileNotFoundException)
            {
                _context.FashionSliders.Remove(fashion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _context.FashionSliders.Remove(fashion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FashionExsist(int id)
        {
            return _context.FashionSliders.Any(x=>x.Id == id);
        }
    }
}
