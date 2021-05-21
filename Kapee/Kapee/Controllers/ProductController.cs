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
using System.Threading.Tasks;

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
            string cookieName = Request.Cookies["product"];
            if (cookieName == null)
            {
                products = new List<CookieProductViewModel>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<CookieProductViewModel>>(cookieName);
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
            Response.Cookies.Append("product", recentlyViewed, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

            var cookieProducts = Request.Cookies.ContainsKey("product") ?  
                JsonConvert.DeserializeObject<List<CookieProductViewModel>>(Request.Cookies["product"]) : 
                new List<CookieProductViewModel>();

            var newProducts = new List<Product>();
            if(cookieProducts.Count > 0)
            {
                foreach (var cookieProduct in cookieProducts)
                {
                    var newProduct = _context.Products
                                               .Include(x => x.Category)
                                               .Include(x => x.SubCategory)
                                               .Include(x => x.ProductGalleries)
                                               .Include(x => x.ProductColors)
                                               .ThenInclude(x => x.Color)
                                               .Include(x => x.ProductSizes)
                                               .ThenInclude(x => x.Size)
                                               .FirstOrDefault(x => x.Id == cookieProduct.Id);
                    newProducts.Add(newProduct);
                }
            }

            ProductViewModel model = new ProductViewModel
            {
                Product = _context.Products.Include(x => x.Brand)
                                           .Include(x => x.Category)
                                           .Include(x => x.SubCategory)
                                           .Include(x => x.ProductGalleries)
                                           .Include(x => x.BigSizePhotos)
                                           .Include(x => x.SmallSizePhotos)
                                           .Include(x => x.Prizes)
                                           .Include(x=>x.ProductColors)
                                           .ThenInclude(x=>x.Color)
                                           .Include(x=>x.ProductSizes)
                                           .ThenInclude(x=>x.Size)
                                           .FirstOrDefault(x => x.Id == id),

                Products = _context.Products.Include(x=>x.ProductGalleries)
                                            .Include(x=>x.Category)
                                            .Include(x=>x.SubCategory)
                                            .Include(x => x.ProductColors)
                                            .ThenInclude(x => x.Color)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size).ToList(),

                RecentlyViewedProducts = newProducts

            };

            

            return View(model);
        }

        public async Task<IActionResult> AddToWish(int? id, string selectedPhotoes)
        {
            if (id == null) return NotFound();

            Product product = await _context.Products.Include(x => x.ProductGalleries).FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound();

            List<WishListWiewModel> wishlistProducts;
            if (Request.Cookies["wishlist"] == null)
            {
                wishlistProducts = new List<WishListWiewModel>();
            }
            else
            {
                wishlistProducts = JsonConvert.DeserializeObject<List<WishListWiewModel>>(Request.Cookies["wishlist"]);
            }

            WishListWiewModel existProduct = wishlistProducts.FirstOrDefault(x => x.Id == id);
            if (existProduct == null)
            {
                WishListWiewModel newproduct = new WishListWiewModel
                {
                    Id = product.Id,
                    Photo = product.ProductGalleries.FirstOrDefault(x => selectedPhotoes.Contains(x.Photo)).Photo
                };
                wishlistProducts.Add(newproduct);
            }

            foreach (var wishlistProduct in wishlistProducts)
            {
                Product dbProduct = _context.Products.FirstOrDefault(x => x.Id == wishlistProduct.Id);
                if (dbProduct != null)
                {
                    wishlistProduct.Price = dbProduct.Price;
                    wishlistProduct.Name = dbProduct.Name;
                }
            }

            string wishlist = JsonConvert.SerializeObject(wishlistProducts);
            Response.Cookies.Append("wishlist", wishlist, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

            var anonymObject = new
            {
                WishlistProductCount = wishlistProducts.Count()
            };

            return Ok(anonymObject);
        }


    }
}
