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
    public class FooterLogoController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public FooterLogoController(AplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var logo = await _context.FooterLogos.ToListAsync();

            return View(logo);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null) return NotFound();

            var logo = await _context.FooterLogos.FirstOrDefaultAsync(x => x.Id == id);
            if (logo == null) return NotFound();

            return View(logo);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("UploadLogo,PhotoLogo,Id,UploadCopyright,PhotoCopyright")] FooterLogo footerLogo)
        {
            if(footerLogo.UploadLogo == null)
            {
                ModelState.AddModelError("UploadLogo", "The Photo field is required.");
            }
            else
            {
                if(footerLogo.UploadLogo.ContentType != "image/jpeg" && footerLogo.UploadLogo.ContentType != "image/png" && footerLogo.UploadLogo.ContentType != "image/gif")
                {
                    ModelState.AddModelError("UploadLogo", "You can only download png, jpg or gif file");
                }
                if(footerLogo.UploadLogo.Length > 1048576)
                {
                    ModelState.AddModelError("UploadLogo", "The file size can be a maximum of 1 MB");
                }
            }

            if(footerLogo.UploadCopyright == null)
            {
                ModelState.AddModelError("UploadCopyright", "The Photo field is required.");
            }
            else
            {
                if (footerLogo.UploadCopyright.ContentType != "image/jpeg" && footerLogo.UploadCopyright.ContentType != "image/png" && footerLogo.UploadCopyright.ContentType != "image/gif")
                {
                    ModelState.AddModelError("UploadCopyright", "You can only download png, jpg or gif file");
                }
                if (footerLogo.UploadCopyright.Length > 1048576)
                {
                    ModelState.AddModelError("UploadCopyright", "The file size can be a maximum of 1 MB");
                }
            }

            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(footerLogo.UploadLogo);
                footerLogo.PhotoLogo = fileName;

                var secondFaleName = _fileManager.Upload(footerLogo.UploadCopyright);
                footerLogo.PhotoCopyright = secondFaleName;

                _context.FooterLogos.Add(footerLogo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(footerLogo);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var logo = await _context.FooterLogos.FirstOrDefaultAsync(x => x.Id == id);
            if (logo == null) return NotFound();

            return View(logo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("UploadLogo,PhotoLogo,Id,UploadCopyright,PhotoCopyright")] FooterLogo footerLogo)
        {
            if (id != footerLogo.Id) return NotFound();

            if(footerLogo.UploadCopyright == null)
            {
                ModelState.AddModelError("UploadCopyright", "The Photo field is required.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(footerLogo.UploadLogo != null)
                    {
                        if (footerLogo.UploadLogo.ContentType != "image/jpeg" && footerLogo.UploadLogo.ContentType != "image/png" && footerLogo.UploadLogo.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("UploadLogo", "You can only download png, jpg or gif file");
                            return View(footerLogo);
                        }

                        if (footerLogo.UploadLogo.Length > 1048576)
                        {
                            ModelState.AddModelError("UploadLogo", "The file size can be a maximum of 1 MB");
                            return View(footerLogo);
                        }

                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", footerLogo.PhotoLogo);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(footerLogo.UploadLogo, "wwwroot/uploads");
                        footerLogo.PhotoLogo = fileName;
                    }

                    if (footerLogo.UploadCopyright != null)
                    {
                        if (footerLogo.UploadCopyright.ContentType != "image/jpeg" && footerLogo.UploadCopyright.ContentType != "image/png" && footerLogo.UploadCopyright.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("UploadCopyright", "You can only download png, jpg or gif file");
                            return View(footerLogo);
                        }

                        if (footerLogo.UploadCopyright.Length > 1048576)
                        {
                            ModelState.AddModelError("UploadCopyright", "The file size can be a maximum of 1 MB");
                            return View(footerLogo);
                        }

                        var secondOldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", footerLogo.PhotoCopyright);
                        _fileManager.Delete(secondOldFile);

                        var secondFileName = _fileManager.Upload(footerLogo.UploadCopyright, "wwwroot/uploads");
                        footerLogo.PhotoCopyright = secondFileName;
                    }

                    _context.Update(footerLogo);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!FooterLogoExsist(footerLogo.Id))
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

            return View(footerLogo);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var logo = await _context.FooterLogos.FirstOrDefaultAsync(x => x.Id == id);
            if (logo == null) return NotFound();

            return View(logo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var logo = await _context.FooterLogos.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", logo.PhotoLogo);
                _fileManager.Delete(oldFile, "wwwroot/uploads");

                var secondOldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", logo.PhotoCopyright);
                _fileManager.Delete(secondOldFile, "wwwroot/uploads");
            }
            catch (FileNotFoundException)
            {
                _context.FooterLogos.Remove(logo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            _context.FooterLogos.Remove(logo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool FooterLogoExsist(int id)
        {
            return _context.FooterLogos.Any(x => x.Id == id);
        }
    }
}
