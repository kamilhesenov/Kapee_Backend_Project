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
    public class WishListController : Controller
    {
        private readonly AplicationDbContext _context;
        public WishListController(AplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            string wishlist = Request.Cookies["wishlist"];
            List<WishListWiewModel> basketProducts = new List<WishListWiewModel>();

            if (wishlist != null)
            {
                basketProducts = JsonConvert.DeserializeObject<List<WishListWiewModel>>(wishlist);

                foreach (WishListWiewModel basketProduct in basketProducts)
                {
                    Product product = _context.Products.Include(x=>x.ProductGalleries).FirstOrDefault(x => x.Id == basketProduct.Id);
                    if (product != null)
                    {
                        basketProduct.Price = product.Price;
                        basketProduct.Photo = product.ProductGalleries.FirstOrDefault(x => x.ProductId == product.Id).Photo;
                        basketProduct.Name = product.Name;
                    }
                    
                }
                
            }

            return View(basketProducts);
        }


        public async Task<IActionResult> AddToWish(int? id)
        {
            if (id == null) return NotFound();
            
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
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

            WishListWiewModel existProduct = wishlistProducts.FirstOrDefault(p => p.Id == id);

            if (existProduct == null)
            {
                WishListWiewModel newproduct = new WishListWiewModel
                {
                    Id = product.Id
                    
                };
                wishlistProducts.Add(newproduct);
            }

            foreach (var wishlistProduct in wishlistProducts)
            {
                Product dbProduct = _context.Products.Include(x=>x.ProductGalleries).FirstOrDefault(x => x.Id == wishlistProduct.Id);
                if (dbProduct != null)
                {
                    wishlistProduct.Price = dbProduct.Price;
                    wishlistProduct.Photo = dbProduct.ProductGalleries.FirstOrDefault(x=>x.ProductId == dbProduct.Id).Photo;
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



        public IActionResult RemoveItem(int? id)
        {
            string wishlist = Request.Cookies["wishlist"];
            List<WishListWiewModel> wishlistProducts = JsonConvert.DeserializeObject<List<WishListWiewModel>>(wishlist);
            WishListWiewModel product = wishlistProducts.FirstOrDefault(p => p.Id == id);
            wishlistProducts.Remove(product);

            foreach (var wishlistProduct in wishlistProducts)
            {
                Product dbProduct = _context.Products.Include(x => x.ProductGalleries).FirstOrDefault(x => x.Id == wishlistProduct.Id);
                if (dbProduct != null)
                {
                    wishlistProduct.Price = dbProduct.Price;
                    wishlistProduct.Photo = dbProduct.ProductGalleries.FirstOrDefault(x => x.ProductId == dbProduct.Id).Photo;
                    wishlistProduct.Name = dbProduct.Name;
                }
                
            }

            string fwishlist = JsonConvert.SerializeObject(wishlistProducts);
            Response.Cookies.Append("wishlist", fwishlist, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

            var anonymObject = new
            {

                WishlistProductCount = wishlistProducts.Count()
            };

            return Ok(anonymObject);
        }
    }
}
