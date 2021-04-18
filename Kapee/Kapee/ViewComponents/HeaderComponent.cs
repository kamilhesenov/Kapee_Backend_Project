using Kapee.Data;
using Kapee.Models;
using Kapee.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.ViewComponents
{
    public class HeaderComponent : ViewComponent
    {
        private readonly AplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public HeaderComponent(AplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            ViewBag.BasketCount = 0;

            var vendor = _context.Venders.FirstOrDefault();
            ViewBag.Username = "";
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.Username = user.UserName;
            }

            if (Request.Cookies["wishlist"] != null)
            {
                List<WishListWiewModel> products = JsonConvert.DeserializeObject<List<WishListWiewModel>>(Request.Cookies["wishlist"]);

                ViewBag.WishlistCount = products.Count();
            }

            HeaderViewModel model = new HeaderViewModel()
            {
                HeaderLogo = _context.HeaderLogos.FirstOrDefault(),
                Categories = _context.Categories.ToList()
            };

            return View(model);
        }
    }
}
