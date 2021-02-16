using Kapee.Data;
using Kapee.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Linq;


namespace Kapee.ViewComponents
{
    public class HeaderComponent : ViewComponent
    {
        private readonly AplicationDbContext _context;
        public HeaderComponent(AplicationDbContext context)
        {
            _context = context;
        }

        public ViewViewComponentResult Invoke()
        {
            HeaderViewModel model = new HeaderViewModel
            {
                HeaderLogo = _context.HeaderLogos.FirstOrDefault(),
                Categories = _context.Categories.ToList()
            };
            return View(model);
        }
    }
}
