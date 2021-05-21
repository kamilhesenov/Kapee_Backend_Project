using Kapee.Data;
using Kapee.Filter;
using Kapee.Models.Header_Footer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HeaderLogoController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public HeaderLogoController(AplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var logo = await _context.HeaderLogos.ToListAsync();

            return View(logo);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var logo = await _context.HeaderLogos.FirstOrDefaultAsync(x => x.Id == id);
            if (logo == null) return NotFound();

            return View(logo);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("MainUpload,MainPhoto,Id,SecondUpload,SecondPhoto")] HeaderLogo headerLogo)
        {
            if (headerLogo.MainUpload == null)
            {
                ModelState.AddModelError("MainUpload", "The Photo field is required.");
            }
            else
            {
                if (headerLogo.MainUpload.ContentType != "image/jpeg" && headerLogo.MainUpload.ContentType != "image/png" && headerLogo.MainUpload.ContentType != "image/gif")
                {
                    ModelState.AddModelError("MainUpload", "You can only download png, jpg or gif file");
                }
                if (headerLogo.MainUpload.Length > 1048576)
                {
                    ModelState.AddModelError("MainUpload", "The file size can be a maximum of 1 MB");
                }
            }

            if (headerLogo.SecondUpload == null)
            {
                ModelState.AddModelError("SecondUpload", "The Photo field is required.");
            }
            else
            {
                if (headerLogo.SecondUpload.ContentType != "image/jpeg" && headerLogo.SecondUpload.ContentType != "image/png" && headerLogo.SecondUpload.ContentType != "image/gif")
                {
                    ModelState.AddModelError("SecondUpload", "You can only download png, jpg or gif file");
                }
                if (headerLogo.SecondUpload.Length > 1048576)
                {
                    ModelState.AddModelError("SecondUpload", "The file size can be a maximum of 1 MB");
                }
            }

            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(headerLogo.MainUpload);
                headerLogo.MainPhoto = fileName;

                var secondFaleName = _fileManager.Upload(headerLogo.SecondUpload);
                headerLogo.SecondPhoto = secondFaleName;

                _context.HeaderLogos.Add(headerLogo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(headerLogo);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var logo = await _context.HeaderLogos.FirstOrDefaultAsync(x => x.Id == id);
            if (logo == null) return NotFound();

            return View(logo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("MainUpload,MainPhoto,Id,SecondUpload,SecondPhoto")] HeaderLogo headerLogo)
        {
            if (id != headerLogo.Id) return NotFound();

            if (headerLogo.SecondUpload == null)
            {
                ModelState.AddModelError("SecondUpload", "The Photo field is required.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (headerLogo.MainUpload != null)
                    {
                        if (headerLogo.MainUpload.ContentType != "image/jpeg" && headerLogo.MainUpload.ContentType != "image/png" && headerLogo.MainUpload.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("MainUpload", "You can only download png, jpg or gif file");
                            return View(headerLogo);
                        }

                        if (headerLogo.MainUpload.Length > 1048576)
                        {
                            ModelState.AddModelError("MainUpload", "The file size can be a maximum of 1 MB");
                            return View(headerLogo);
                        }

                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", headerLogo.MainPhoto);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(headerLogo.MainUpload, "wwwroot/uploads");
                        headerLogo.MainPhoto = fileName;
                    }

                    if (headerLogo.SecondUpload != null)
                    {
                        if (headerLogo.SecondUpload.ContentType != "image/jpeg" && headerLogo.SecondUpload.ContentType != "image/png" && headerLogo.SecondUpload.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("SecondUpload", "You can only download png, jpg or gif file");
                            return View(headerLogo);
                        }

                        if (headerLogo.SecondUpload.Length > 1048576)
                        {
                            ModelState.AddModelError("SecondUpload", "The file size can be a maximum of 1 MB");
                            return View(headerLogo);
                        }

                        var secondOldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", headerLogo.SecondPhoto);
                        _fileManager.Delete(secondOldFile);

                        var secondFileName = _fileManager.Upload(headerLogo.SecondUpload, "wwwroot/uploads");
                        headerLogo.SecondPhoto = secondFileName;
                    }

                    _context.Update(headerLogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeaderLogoExsist(headerLogo.Id))
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

            return View(headerLogo);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var logo = await _context.HeaderLogos.FirstOrDefaultAsync(x => x.Id == id);
            if (logo == null) return NotFound();

            return View(logo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var logo = await _context.HeaderLogos.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", logo.MainPhoto);
                _fileManager.Delete(oldFile, "wwwroot/uploads");

                var secondOldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", logo.SecondPhoto);
                _fileManager.Delete(secondOldFile, "wwwroot/uploads");
            }
            catch (FileNotFoundException)
            {
                _context.HeaderLogos.Remove(logo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            _context.HeaderLogos.Remove(logo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool HeaderLogoExsist(int id)
        {
            return _context.HeaderLogos.Any(x => x.Id == id);
        }
    }
}
