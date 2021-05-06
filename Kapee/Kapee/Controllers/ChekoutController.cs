using Kapee.Data;
using Kapee.Models;
using Kapee.Models.Product;
using Kapee.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Controllers
{
    public class ChekoutController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public ChekoutController(AplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            
            var existUser = await _userManager.FindByNameAsync(User.Identity.Name);
           

            decimal number = 0;
            ViewBag.BasketTotalPrice = "";
            string cartlist = Request.Cookies["cartlist"];

            CheckoutViewModel checkoutViewModel = new CheckoutViewModel
            {
                FullName = existUser.UserName,
                Email = existUser.Email,
                Phone = existUser.PhoneNumber
            };

            List<BasketViewModel> basketProducts = new List<BasketViewModel>();

            if (cartlist != null)
            {
                basketProducts = JsonConvert.DeserializeObject<List<BasketViewModel>>(cartlist);

                foreach (BasketViewModel basketProduct in basketProducts)
                {
                    Product product = _context.Products.Include(x => x.ProductGalleries).FirstOrDefault(x => x.Id == basketProduct.Id);
                    if (product != null)
                    {
                        basketProduct.Price = product.Price;
                        basketProduct.Photo = product.ProductGalleries.FirstOrDefault(x => x.ProductId == product.Id).Photo;
                        basketProduct.Name = product.Name;
                        basketProduct.DbCount = product.Count;
                    }
                    basketProduct.ProductTotalPrice = basketProduct.BasketCount * basketProduct.Price;
                    number += basketProduct.ProductTotalPrice;

                }

            }
            checkoutViewModel.BasketViewModels = basketProducts;

            return View(checkoutViewModel);
        }
    }
}
