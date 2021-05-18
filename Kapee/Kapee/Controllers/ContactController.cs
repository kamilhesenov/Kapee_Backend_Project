using Kapee.Data;
using Kapee.Models;
using Kapee.Models.Header_Footer;
using Kapee.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Controllers
{
    public class ContactController : Controller
    {
        private readonly AplicationDbContext _context;
        public ContactController(AplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ContactViewModel model = new ContactViewModel
            {
                Setting = _context.Settings.FirstOrDefault()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Send(ContactViewModel model)
        {
            if(string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Message))
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Contact contact = new Contact
                {
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message
                };
               _context.Contacts.Add(contact);
                _context.SaveChanges();

                return NoContent();
            }

            return View();
        }
    }
}
