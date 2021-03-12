using Kapee.Data;
using Kapee.Models.Product;
using Kapee.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Kapee.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AplicationDbContext _context;
        public CategoryController(AplicationDbContext context)
        {
            _context = context;
        }

        [Route("category")]
        public IActionResult Index(int id, int page, int pageSize)
        {
            //var items = _context.Products.Include(x => x.ProductGalleries)
            //                             .Include(x => x.Category)
            //                             .ThenInclude(x => x.SubCategories)
            //                             .Include(x => x.ProductColors)
            //                             .ThenInclude(x => x.Color)
            //                             .Include(x => x.ProductSizes)
            //                             .ThenInclude(x => x.Size)
            //                             .AsNoTracking().OrderBy(x => x.Id);
            //var pagingData = await PagingList.CreateAsync(items, pageSize, page);

            CategoryViewModel model = new CategoryViewModel
            {
                Category = _context.Categories.Include(x => x.Products)
                                              .ThenInclude(x => x.SubCategories)
                                              .FirstOrDefault(x => x.Id == id),

                Products = _context.Products
                                            .Where(x=>x.CategoryId == id)
                                            .Include(x => x.ProductGalleries)
                                            .Include(x => x.Category)
                                            .ThenInclude(x => x.SubCategories)
                                            .Include(x => x.ProductColors)
                                            .ThenInclude(x => x.Color)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size).ToList(),

                Categories = _context.Categories.Include(x => x.SubCategories).ToList(),

                Colors = _context.Colors.Include(x => x.ProductColors).ToList(),

                Sizes = _context.Sizes.Include(x => x.ProductSizes).ToList(),

                //PagingList = pagingData

            };

            //if(colorId != null)
            //{
            //    var products = new List<Product>();
            //    var productColors = _context.ProductColors.Where(x=>x.ColorId == colorId);
            //    foreach (var productColor in productColors)
            //    {
            //        var product = _context.Products
            //                .Include(x => x.ProductGalleries)
            //                .Include(x => x.Category)
            //                .ThenInclude(x => x.SubCategories)
            //                .Include(x => x.ProductColors)
            //                .ThenInclude(x => x.Color)
            //                .Include(x => x.ProductSizes)
            //                .ThenInclude(x => x.Size)
            //                .FirstOrDefault(x => x.Id == productColor.ProductId);
            //        products.Add(product);
            //    }
            //    model.Products = products;
                

                
            //}

            return View(model);
        }

        public IActionResult CategoryColor([FromForm] List<int> ColorsId, int categoryId)
        {
           
            var productColors = _context.ProductColors
                                  .Where(x => ColorsId.Contains(x.ColorId)).ToList();
            var products = new List<Product>();
            foreach (var item in productColors)
            {
                var product = _context.Products
                                            .Include(x => x.ProductGalleries)
                                            .Include(x => x.Category)
                                            .ThenInclude(x => x.SubCategories)
                                            .Include(x => x.ProductColors)
                                            .ThenInclude(x => x.Color)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size)
                                            .FirstOrDefault(x => x.Id == item.ProductId);

                if(product.CategoryId == categoryId)
                {
                    var existProduct = products.FirstOrDefault(x => x.Id == product.Id);
                    if(existProduct == null)
                    {
                        products.Add(product);
                    }
                    
                }
                
                
            }

            return PartialView("_ColorProducts",products);
        }

        public IActionResult CategorySize([FromForm]  List<int> SizesId, int categoryId)
        {
            var productSizes = _context.ProductSizes
                               .Where(x => SizesId.Contains(x.SizeId)).ToList();

            var products = new List<Product>();

            foreach (var item in productSizes)
            {
                var product = _context.Products
                                            .Include(x => x.ProductGalleries)
                                            .Include(x => x.Category)
                                            .ThenInclude(x => x.SubCategories)
                                            .Include(x => x.ProductColors)
                                            .ThenInclude(x => x.Color)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size)
                                            .FirstOrDefault(x => x.Id == item.ProductId);

                if(product.CategoryId == categoryId)
                {
                    var exsistProduct = products.FirstOrDefault(x => x.Id == product.Id);
                    if(exsistProduct == null)
                    {
                        products.Add(product);
                    }
                }
            }

            return PartialView("_SizeProduct", products);
        }

        public IActionResult CategoryPrice([FromForm] int[] Prices, int categoryId)
        {
            var products = _context.Products
                                            .Include(x => x.ProductGalleries)
                                            .Include(x => x.Category)
                                            .ThenInclude(x => x.SubCategories)
                                            .Include(x => x.ProductColors)
                                            .ThenInclude(x => x.Color)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size)
                                            .Where(x=>x.Price > Prices[0] &&  x.Price<= Prices[1] && x.CategoryId == categoryId)
                                            .ToList();

            return PartialView("_SizeProduct", products);
        }

        public IActionResult CategoryStar([FromForm] int Star, int categoryId)
        {
            var products = _context.Products
                                            .Include(x => x.ProductGalleries)
                                            .Include(x => x.Category)
                                            .ThenInclude(x => x.SubCategories)
                                            .Include(x => x.ProductColors)
                                            .ThenInclude(x => x.Color)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size)
                                            .Where(x => Math.Floor((decimal)x.StarCount) == Star && x.CategoryId == categoryId)
                                            .ToList();

            return PartialView("_SizeProduct", products);
        }

    }
}
