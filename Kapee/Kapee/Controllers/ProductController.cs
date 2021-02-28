using Kapee.Data;
using Kapee.Models.Product;
using Kapee.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Kapee.Controllers
{
    public class ProductController : Controller
    {
        private readonly AplicationDbContext _context;
        public ProductController(AplicationDbContext context)
        {
            _context = context;
        }

        [Route("product")]
        public IActionResult Index(int id)
        {

            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            List<CookieProductViewModel> products;
            string existBasket = Request.Cookies["recentlyViewed"];
            if (existBasket == null)
            {
                products = new List<CookieProductViewModel>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<CookieProductViewModel>>(existBasket);
            }
            var existProduct = products.FirstOrDefault(x => x.Id == product.Id);
            if (existProduct == null)
            {
                CookieProductViewModel cookie = new CookieProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name
                };
                products.Add(cookie);
            }
            
            string recentlyViewed = JsonConvert.SerializeObject(products);
            Response.Cookies.Append("recentlyViewed", recentlyViewed, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

            var cookieProducts = JsonConvert.DeserializeObject<List<CookieProductViewModel>>(Request.Cookies["recentlyViewed"]);
            var newProducts = new List<Product>();
            foreach (var cookieProduct in cookieProducts)
            {
                var newProduct = _context.Products
                                           .Include(x => x.Category)
                                           .Include(x => x.SubCategories)
                                           .Include(x => x.ProductFeatureds)
                                           .Include(x => x.ProductGalleries)
                                           .FirstOrDefault(x => x.Id == cookieProduct.Id);
                newProducts.Add(newProduct);
            }

            ProductViewModel model = new ProductViewModel
            {
                Product = _context.Products.Include(x => x.Brand)
                                           .Include(x => x.Category)
                                           .Include(x => x.SubCategories)
                                           .Include(x => x.ProductFeatureds)
                                           .Include(x => x.ProductGalleries)
                                           .Include(x => x.BigSizePhotos)
                                           .Include(x => x.SmallSizePhotos)
                                           .Include(x => x.Prizes)
                                           .FirstOrDefault(x => x.Id == id),

                Products = _context.Products.Include(x=>x.ProductGalleries)
                                            .Include(x=>x.Category)
                                            .ThenInclude(x=>x.SubCategories)
                                            .Include(x=>x.ProductFeatureds).ToList(),

                RecentlyViewedProducts = newProducts

            };

            

            return View(model);
        }


    }
}
