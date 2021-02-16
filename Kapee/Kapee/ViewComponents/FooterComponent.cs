using Kapee.Data;
using Kapee.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Linq;


namespace Kapee.ViewComponents
{
    public class FooterComponent : ViewComponent
    {
        private readonly AplicationDbContext _context;
        public FooterComponent(AplicationDbContext context)
        {
            _context = context;
        }

        public ViewViewComponentResult Invoke()
        {
            FooterViewModel model = new FooterViewModel
            {
                Setting = _context.Settings.FirstOrDefault(),
                SocialLink = _context.SocialLinks.FirstOrDefault(),
                FooterLogo = _context.FooterLogos.FirstOrDefault()
            };

            return View(model);
        }
    }
}
