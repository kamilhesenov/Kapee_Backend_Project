using Kapee.Data;
using Kapee.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Areas.UserPanel.Controllers.Home
{
    [Area("UserPanel")]
    public class HomeInfoController : Controller
    {
        private readonly AplicationDbContext _context;
        public HomeInfoController(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var info = await _context.Infos.ToListAsync();

            return View(info);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var info = await _context.Infos.FirstOrDefaultAsync(x => x.Id == id);
            if (info == null) return NotFound();

            return View(info);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Icon")] Info info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(info);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(info);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var info = await _context.Infos.FirstOrDefaultAsync(x => x.Id == id);
            if (info == null) return NotFound();

            return View(info);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,Content,Icon")] Info info)
        {
            if (id != info.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoExists(info.Id))
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

            return View(info);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var info = await _context.Infos.FirstOrDefaultAsync(x => x.Id == id);
            if (info == null) return NotFound();

            return View(info);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var info = await _context.Infos.FirstOrDefaultAsync(x => x.Id == id);
            _context.Infos.Remove(info);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool InfoExists(int id)
        {
            return _context.Infos.Any(x => x.Id == id);
        }
    }
}
