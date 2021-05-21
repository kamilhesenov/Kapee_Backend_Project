using Kapee.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Kapee.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class ContactController : Controller
    {
        private readonly AplicationDbContext _context;
        public ContactController(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var contact = await _context.Contacts.ToListAsync();

            return View(contact);
        }
    }
}
