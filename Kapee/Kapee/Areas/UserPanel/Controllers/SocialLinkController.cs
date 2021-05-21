using Kapee.Data;
using Kapee.Models.Header_Footer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class SocialLinkController : Controller
    {
        private readonly AplicationDbContext _context;
        public SocialLinkController(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var socialLink = await _context.SocialLinks.ToListAsync();

            return View(socialLink);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var socialLink = await _context.SocialLinks.FirstOrDefaultAsync(x => x.Id == id);
            if (socialLink == null) return NotFound();

            return View(socialLink);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Facebook,Twitter,Linkedin,Instagram,Flickr,Rss,Youtube")] SocialLink socialLink)
        {
            if (ModelState.IsValid)
            {
                await _context.SocialLinks.AddAsync(socialLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(socialLink);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var socialLink = await _context.SocialLinks.FirstOrDefaultAsync(x => x.Id == id);
            if (socialLink == null) return NotFound();

            return View(socialLink);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Facebook,Twitter,Linkedin,Instagram,Flickr,Rss,Youtube")] SocialLink socialLink)
        {
            if (id != socialLink.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialLinkExists(socialLink.Id))
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

            return View(socialLink);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var socialLink = await _context.SocialLinks.FirstOrDefaultAsync(x => x.Id == id);
            if (socialLink == null) return NotFound();

            return View(socialLink);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var socialLink = await _context.SocialLinks.FirstOrDefaultAsync(x => x.Id == id);
            _context.SocialLinks.Remove(socialLink);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool SocialLinkExists(int id)
        {
            return _context.SocialLinks.Any(x => x.Id == id);
        }
    }
}
