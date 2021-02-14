﻿using Kapee.Data;
using Kapee.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Controllers
{
    public class HomeController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,AplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                CategoryCarusels = _context.CategoryCarusels.ToList(),
                Brands = _context.Brands.ToList(),
                Infos = _context.Infos.ToList(),
                CategoryCallections = _context.CategoryCallections.ToList(),
                TestimonialItem = _context.TestimonialItems.FirstOrDefault(),
                Testimonials = _context.Testimonials.ToList()
            };

            return View(model);
        }
       
    }
}