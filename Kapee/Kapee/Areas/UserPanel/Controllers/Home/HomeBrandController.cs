using Kapee.Data;
using Kapee.Filter;
using Kapee.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Areas.UserPanel.Controllers.Home
{
    [Area("UserPanel")]
    public class HomeBrandController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public HomeBrandController(AplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public async Task<IActionResult> Index()
        {
            var brand = await _context.Brands.ToListAsync();

            return View(brand);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null) return NotFound();

            return View(brand);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Upload,Photo,Id")] Brand brand)
        {
            if (brand.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }
            else
            {
                if (brand.Upload.ContentType != "image/jpeg" && brand.Upload.ContentType != "image/png" && brand.Upload.ContentType != "image/gif")
                {
                    ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                }

                if (brand.Upload.Length > 1048576)
                {
                    ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                }

            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(brand.Upload);
                brand.Photo = fileName;

                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null) return NotFound();

            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Upload,Photo,Id")] Brand brand)
        {
            if (id != brand.Id) return NotFound();

            if (brand.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }

            if (ModelState.IsValid)
            {

                try
                {
                    if (brand.Upload != null)
                    {
                        if (brand.Upload.ContentType != "image/jpeg" && brand.Upload.ContentType != "image/png" && brand.Upload.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                            return View(brand);
                        }

                        if (brand.Upload.Length > 1048576)
                        {
                            ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                            return View(brand);
                        }

                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", brand.Photo);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(brand.Upload, "wwwroot/uploads");
                        brand.Photo = fileName;
                    }

                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExsist(brand.Id))
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
            return View(brand);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null) return NotFound();

            return View(brand);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", brand.Photo);
                _fileManager.Delete(oldFile, "wwwroot/uploads");
            }
            catch (FileNotFoundException)
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExsist(int id)
        {
            return _context.Brands.Any(x => x.Id == id);
        }
    }
}
