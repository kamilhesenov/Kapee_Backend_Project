using Kapee.Data;
using Kapee.Models.Product;
using Kapee.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Index(int id, int? page)
        {
            

            ViewBag.PageCount = Math.Ceiling((decimal)_context.Products.Where(x=>x.CategoryId == id).Count() / 5);
            ViewBag.Page = page;
            CategoryViewModel model = new CategoryViewModel();
            if (page == null)
            {


                model.Category = _context.Categories.Include(x => x.Products)
                                          .Include(x => x.SubCategories)
                                          .FirstOrDefault(x => x.Id == id);

                model.Products = _context.Products
                                            .Where(x => x.CategoryId == id)
                                            .Include(x => x.ProductGalleries)
                                            .Include(x => x.Category)
                                            .Include(x => x.SubCategory)
                                            .Include(x => x.ProductColors)
                                            .ThenInclude(x => x.Color)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size)
                                            .Take(5)
                                            .ToList();

                model.Categories = _context.Categories.Include(x => x.SubCategories).ToList();

                model.Colors = _context.Colors.Include(x => x.ProductColors).ToList();

                model.Sizes = _context.Sizes.Include(x => x.ProductSizes).ToList();

             
                return View(model);
            }
            else
            {

                model.Category = _context.Categories.Include(x => x.Products)
                                              .Include(x => x.SubCategories)
                                              .FirstOrDefault(x => x.Id == id);

                model.Products = _context.Products
                                            .Where(x => x.CategoryId == id)
                                            .Include(x => x.ProductGalleries)
                                            .Include(x => x.Category)
                                            .Include(x => x.SubCategory)
                                            .Include(x => x.ProductColors)
                                            .ThenInclude(x => x.Color)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size)
                                            .Skip(((int)page - 1) * 5)
                                            .Take(5)
                                            .ToList();

                model.Categories = _context.Categories.Include(x => x.SubCategories).ToList();

                model.Colors = _context.Colors.Include(x => x.ProductColors).ToList();

                model.Sizes = _context.Sizes.Include(x => x.ProductSizes).ToList();



                
                return View(model);
            }

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
                                            .Include(x => x.SubCategory)
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
                                            .Include(x => x.SubCategory)
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
                                            .Include(x => x.SubCategory)
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
                                            .Include(x => x.SubCategory)
                                            .Include(x => x.ProductColors)
                                            .ThenInclude(x => x.Color)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size)
                                            .Where(x => Math.Floor((decimal)x.StarCount) == Star && x.CategoryId == categoryId)
                                            .ToList();

            return PartialView("_SizeProduct", products);
        }

        public IActionResult SubCategoryDetail(int id)
        {
            CategoryViewModel model = new CategoryViewModel
            {
                SubCategory = _context.SubCategories.FirstOrDefault(x => x.Id == id),

                Categories = _context.Categories.Include(x => x.SubCategories).ToList(),

                Products = _context.Products
                                            .Where(x => x.SubCategoryId == id)
                                            .Include(x => x.ProductGalleries)
                                            .Include(x => x.Category)
                                            .Include(x => x.SubCategory)
                                            .Include(x => x.ProductColors)
                                            .ThenInclude(x => x.Color)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size)
                                            .ToList(),

         };

            return View(model);
        }

        public IActionResult PaginSize(int categoryId, int PagingSize, int page)
        {
            if(page == 0)
            {
                page = 1;
            }

            var products = _context.Products
                                            .Where(x => x.CategoryId == categoryId)
                                            .Include(x => x.ProductGalleries)
                                            .Include(x => x.Category)
                                            .Include(x => x.SubCategory)
                                            .Include(x => x.ProductColors)
                                            .ThenInclude(x => x.Color)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size)
                                            .Skip(((int)page - 1) * PagingSize)
                                            .Take(PagingSize)
                                            .ToList();

            return PartialView("_SizeProduct", products);
        }

    }
}
