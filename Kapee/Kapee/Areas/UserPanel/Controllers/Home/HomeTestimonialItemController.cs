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
    public class HomeTestimonialItemController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public HomeTestimonialItemController(AplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public async Task<IActionResult> Index()
        {
            var testimonial = await _context.TestimonialItems.ToListAsync();

            return View(testimonial);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var testimonial = await _context.TestimonialItems.FirstOrDefaultAsync(x => x.Id == id);
            if (testimonial == null) return NotFound();

            return View(testimonial);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Upload,Photo,Id")] TestimonialItem testimonial)
        {
            if (testimonial.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }
            else
            {
                if (testimonial.Upload.ContentType != "image/jpeg" && testimonial.Upload.ContentType != "image/png" && testimonial.Upload.ContentType != "image/gif")
                {
                    ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                }

                if (testimonial.Upload.Length > 1048576)
                {
                    ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                }

            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(testimonial.Upload);
                testimonial.Photo = fileName;

                _context.Add(testimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testimonial);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var testimonial = await _context.TestimonialItems.FirstOrDefaultAsync(x => x.Id == id);
            if (testimonial == null) return NotFound();

            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Upload,Photo,Id")] TestimonialItem testimonial)
        {
            if (id != testimonial.Id) return NotFound();

            if (testimonial.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }

            if (ModelState.IsValid)
            {

                try
                {
                    if (testimonial.Upload != null)
                    {
                        if (testimonial.Upload.ContentType != "image/jpeg" && testimonial.Upload.ContentType != "image/png" && testimonial.Upload.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                            return View(testimonial);
                        }

                        if (testimonial.Upload.Length > 1048576)
                        {
                            ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                            return View(testimonial);
                        }

                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", testimonial.Photo);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(testimonial.Upload, "wwwroot/uploads");
                        testimonial.Photo = fileName;
                    }

                    _context.Update(testimonial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimonialExsist(testimonial.Id))
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
            return View(testimonial);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var testimonial = await _context.TestimonialItems.FirstOrDefaultAsync(x => x.Id == id);
            if (testimonial == null) return NotFound();

            return View(testimonial);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var testimonial = await _context.TestimonialItems.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", testimonial.Photo);
                _fileManager.Delete(oldFile, "wwwroot/uploads");
            }
            catch (FileNotFoundException)
            {
                _context.TestimonialItems.Remove(testimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _context.TestimonialItems.Remove(testimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestimonialExsist(int id)
        {
            return _context.TestimonialItems.Any(x => x.Id == id);
        }
    }
}
