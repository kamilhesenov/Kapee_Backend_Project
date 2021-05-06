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
    public class BasketController : Controller
    {
        private readonly AplicationDbContext _context;
        public BasketController(AplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            decimal number = 0;
            ViewBag.BasketTotalPrice = "";
            string cartlist = Request.Cookies["cartlist"];
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
                        basketProduct.Name = product.Name;
                        basketProduct.DbCount = product.Count;
                    }
                    basketProduct.ProductTotalPrice = basketProduct.BasketCount * basketProduct.Price;
                    number += basketProduct.ProductTotalPrice;

                }

            }

            return View(basketProducts);
        }

        public async Task<IActionResult> AddToCart(int? id, string selectedPhotos)
        {
            decimal basketTotalPrice = 0;
            if (id == null) return NotFound();

            Product product = await _context.Products.Include(x=>x.ProductGalleries).FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound();

            List<BasketViewModel> cartlistProducts;
            if (Request.Cookies["cartlist"] == null)
            {
                cartlistProducts = new List<BasketViewModel>();
            }
            else
            {
                cartlistProducts = JsonConvert.DeserializeObject<List<BasketViewModel>>(Request.Cookies["cartlist"]);
            }

            BasketViewModel existProduct = cartlistProducts.FirstOrDefault(p => p.Id == id);

            if (existProduct == null)
            {
                BasketViewModel newproduct = new BasketViewModel
                {
                    Id = product.Id,
                    BasketCount = 1,
                    Photo = product.ProductGalleries.FirstOrDefault(x => selectedPhotos.Contains(x.Photo)).Photo

            };
                cartlistProducts.Add(newproduct);
            }
            else
            {
                existProduct.BasketCount++;
            }

            foreach (var cartlistProduct in cartlistProducts)
            {
                Product dbProduct = _context.Products.FirstOrDefault(x => x.Id == cartlistProduct.Id);
                if (dbProduct != null)
                {
                    cartlistProduct.Price = dbProduct.Price;
                    cartlistProduct.Name = dbProduct.Name;
                    cartlistProduct.DbCount = dbProduct.Count;

                }
                cartlistProduct.ProductTotalPrice = cartlistProduct.BasketCount * cartlistProduct.Price;
                basketTotalPrice += cartlistProduct.ProductTotalPrice;

            }

            string cartlist = JsonConvert.SerializeObject(cartlistProducts);
            Response.Cookies.Append("cartlist", cartlist, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            var anonymObject = new
            {
                BasketTotalPrice = basketTotalPrice,
                CartlistProductCount = cartlistProducts.Count()
            };

            return Ok(anonymObject);
        }

        public IActionResult RemoveItem(int? id)
        {
            decimal basketTotalPrice = 0;
            string cartlist = Request.Cookies["cartlist"];
            List<BasketViewModel> cartlistProducts = JsonConvert.DeserializeObject<List<BasketViewModel>>(cartlist);
            BasketViewModel product = cartlistProducts.FirstOrDefault(p => p.Id == id);
            cartlistProducts.Remove(product);

            foreach (var cartlistProduct in cartlistProducts)
            {
                Product dbProduct = _context.Products.Include(x => x.ProductGalleries).FirstOrDefault(x => x.Id == cartlistProduct.Id);
                if (dbProduct != null)
                {
                    cartlistProduct.Price = dbProduct.Price;
                    cartlistProduct.Photo = dbProduct.ProductGalleries.FirstOrDefault(x => x.ProductId == dbProduct.Id).Photo;
                    cartlistProduct.Name = dbProduct.Name;
                    cartlistProduct.DbCount = dbProduct.Count;
                }
                cartlistProduct.ProductTotalPrice = cartlistProduct.BasketCount * cartlistProduct.Price;
                basketTotalPrice += cartlistProduct.ProductTotalPrice;

            }

            string fcartlist = JsonConvert.SerializeObject(cartlistProducts);
            Response.Cookies.Append("cartlist", fcartlist, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

            var anonymObject = new
            {
                BasketTotalPrice = basketTotalPrice,
                CartlistProductCount = cartlistProducts.Count()
            };

            return Ok(anonymObject);
        }

        public IActionResult ProductCountPlus([FromForm] int id)
        {
            int basketProductDbCount = _context.Products.FirstOrDefault(x => x.Id == id).Count;
            decimal basketTotalPrice = 0;
            decimal productTotalPrice = 0;

            string cartlist = Request.Cookies["cartlist"];
            List<BasketViewModel> cartlistProducts = JsonConvert.DeserializeObject<List<BasketViewModel>>(cartlist);
            BasketViewModel product = cartlistProducts.FirstOrDefault(p => p.Id == id);

            product.BasketCount++;
            int basketCount = product.BasketCount;

            foreach (var cartlistProduct in cartlistProducts)
            {
                Product dbProduct = _context.Products.Include(x => x.ProductGalleries).FirstOrDefault(x => x.Id == cartlistProduct.Id);
                if (dbProduct != null)
                {
                    cartlistProduct.Price = dbProduct.Price;
                    cartlistProduct.Photo = dbProduct.ProductGalleries.FirstOrDefault(x => x.ProductId == dbProduct.Id).Photo;
                    cartlistProduct.Name = dbProduct.Name;
                    cartlistProduct.DbCount = dbProduct.Count;
                }
                cartlistProduct.ProductTotalPrice = cartlistProduct.BasketCount * cartlistProduct.Price;
                if (cartlistProduct.Id == id)
                {
                    productTotalPrice = cartlistProduct.ProductTotalPrice;
                }
                basketTotalPrice += cartlistProduct.ProductTotalPrice;
            }

            string fcartlist = JsonConvert.SerializeObject(cartlistProducts);
            Response.Cookies.Append("cartlist", fcartlist, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            var anonymObject = new
            {
                BasketProducts = cartlistProducts,
                ProductBasketCount = basketCount,
                BasketTotalPrice = basketTotalPrice,
                ProductTotalPrice = productTotalPrice,
                BasketProductDbCount = basketProductDbCount,
                ProductId = product.Id
            };
            return Ok(anonymObject);
        }

        public IActionResult ProductCountMinus(int? id)
        {
            decimal basketTotalPrice = 0;
            decimal productTotalPrice = 0;

            string cartlist = Request.Cookies["cartlist"];
            List<BasketViewModel> cartlistProducts = JsonConvert.DeserializeObject<List<BasketViewModel>>(cartlist);
            BasketViewModel product = cartlistProducts.FirstOrDefault(p => p.Id == id);

            if (product.BasketCount > 1)
            {
                product.BasketCount--;
            }
            else
            {
                cartlistProducts.Remove(product);
            }

            int basketCount = product.BasketCount;

            foreach (var cartlistProduct in cartlistProducts)
            {
                Product dbProduct = _context.Products.Include(x => x.ProductGalleries).FirstOrDefault(x => x.Id == cartlistProduct.Id);
                if (dbProduct != null)
                {
                    cartlistProduct.Price = dbProduct.Price;
                    cartlistProduct.Photo = dbProduct.ProductGalleries.FirstOrDefault(x => x.ProductId == dbProduct.Id).Photo;
                    cartlistProduct.Name = dbProduct.Name;
                    cartlistProduct.DbCount = dbProduct.Count;
                }
                cartlistProduct.ProductTotalPrice = cartlistProduct.BasketCount * cartlistProduct.Price;
                if (cartlistProduct.Id == id)
                {
                    productTotalPrice = cartlistProduct.ProductTotalPrice;
                }
                basketTotalPrice += cartlistProduct.ProductTotalPrice;
            }

            string fcartlist = JsonConvert.SerializeObject(cartlistProducts);
            Response.Cookies.Append("cartlist", fcartlist, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            var anonymObject = new
            {
                BasketProducts = cartlistProducts,
                ProductBasketCount = basketCount,
                BasketTotalPrice = basketTotalPrice,
                ProductTotalPrice = productTotalPrice
            };
            return Ok(anonymObject);
        }
    }
}
