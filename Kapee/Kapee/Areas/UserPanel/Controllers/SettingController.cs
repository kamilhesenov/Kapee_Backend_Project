using Kapee.Data;
using Kapee.Models.Header_Footer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class SettingController : Controller
    {
        private readonly AplicationDbContext _context;
        public SettingController(AplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var setting = await _context.Settings.ToListAsync();

            return View(setting);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (setting == null) return NotFound();

            return View(setting);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Address,Phone,Email")] Setting setting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setting);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(setting);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (setting == null) return NotFound();

            return View(setting);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Address,Phone,Email")] Setting setting)
        {
            if (id != setting.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(setting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingExists(setting.Id))
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

            return View(setting);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (setting == null) return NotFound();

            return View(setting);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            _context.Settings.Remove(setting);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool SettingExists(int id)
        {
            return _context.Settings.Any(x => x.Id == id);
        }
    }
}
