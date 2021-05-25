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
    public class HomeNewsController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public HomeNewsController(AplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _context.Newses.ToListAsync();

            return View(news);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var news = await _context.Newses.FirstOrDefaultAsync(x => x.Id == id);
            if (news == null) return NotFound();

            return View(news);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Upload,Photo,Id,Content,Description,Link,AddedBy,Date")] News news)
        {
            if (news.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }
            else
            {
                if (news.Upload.ContentType != "image/jpeg" && news.Upload.ContentType != "image/png" && news.Upload.ContentType != "image/gif")
                {
                    ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                }

                if (news.Upload.Length > 1048576)
                {
                    ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                }

            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(news.Upload);
                news.Photo = fileName;

                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var news = await _context.Newses.FirstOrDefaultAsync(x => x.Id == id);
            if (news == null) return NotFound();

            return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Upload,Photo,Id,Content,Description,Link,AddedBy,Date")] News news)
        {
            if (id != news.Id) return NotFound();

            if (news.Upload == null)
            {
                ModelState.AddModelError("Upload", "The Photo field is required.");
            }

            if (ModelState.IsValid)
            {

                try
                {
                    if (news.Upload != null)
                    {
                        if (news.Upload.ContentType != "image/jpeg" && news.Upload.ContentType != "image/png" && news.Upload.ContentType != "image/gif")
                        {
                            ModelState.AddModelError("Upload", "You can only download png, jpg or gif file");
                            return View(news);
                        }

                        if (news.Upload.Length > 1048576)
                        {
                            ModelState.AddModelError("Upload", "The file size can be a maximum of 1 MB");
                            return View(news);
                        }

                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", news.Photo);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(news.Upload, "wwwroot/uploads");
                        news.Photo = fileName;
                    }

                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExsist(news.Id))
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
            return View(news);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var news = await _context.Newses.FirstOrDefaultAsync(x => x.Id == id);
            if (news == null) return NotFound();

            return View(news);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var news = await _context.Newses.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", news.Photo);
                _fileManager.Delete(oldFile, "wwwroot/uploads");
            }
            catch (FileNotFoundException)
            {
                _context.Newses.Remove(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _context.Newses.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExsist(int id)
        {
            return _context.Newses.Any(x => x.Id == id);
        }
    }
}
