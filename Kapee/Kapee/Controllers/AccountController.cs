using Kapee.Data;
using Kapee.Models;
using Kapee.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapee.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager,AplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

       
        public IActionResult Register()
        {
            List<IdentityRole> allroles = _roleManager.Roles.ToList();
            List<IdentityRole> roles = new List<IdentityRole>();
            foreach (var item in allroles)
            {
                if (item.Name != "Admin")
                {
                    roles.Add(item);
                }
            }

            ViewBag.allRoles = new SelectList(roles, "Id", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerVM, string role)
        {
            List<IdentityRole> allroles = _roleManager.Roles.ToList();
            List<IdentityRole> roles = new List<IdentityRole>();
            foreach (var item in allroles)
            {
                if (item.Name != "Admin")
                {
                    roles.Add(item);
                }
            }

            ViewBag.allRoles = new SelectList(roles, "Id", "Name");



            if (!ModelState.IsValid) return View();
            AppUser newUser = new AppUser
            {
                UserName = registerVM.UserName,
                Email = registerVM.Email,
            };

            

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }

            
            

            IdentityRole dbRole = await _roleManager.FindByIdAsync(role);
            await _userManager.AddToRoleAsync(newUser, dbRole.Name);

            await _signInManager.SignInAsync(newUser, true);

            if (dbRole.ToString() == "User")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("VendorCreate", "Account");
            }


        }


        //public async Task CreateRole()
        //{
        //    if (!await _roleManager.RoleExistsAsync("Admin"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    }
        //    if (!await _roleManager.RoleExistsAsync("User"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        //    }
        //    if (!await _roleManager.RoleExistsAsync("Vendor"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Vendor" });
        //    }
        //}


        public IActionResult VendorCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VendorCreate(VenderCreateViewModel vender)
        {
            //var existEmployer = await _context.Venders.FirstOrDefaultAsync(x => x.Email == vender.Email);
            //if (existEmployer != null)
            //{
            //    ModelState.AddModelError("", "User Exist");
            //    return View();
            //}

            if (!ModelState.IsValid) return View();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            Vender newVender = new Vender
            {
                Name = vender.Name,
                Surname = vender.Surname,
                Phone = vender.Phone,
                ShopName = vender.ShopName,
                ShopLogoUrl = vender.ShopLogoUrl,
                AppUserId = user.Id

            };
            
            await _context.Venders.AddAsync(newVender);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Login()
        {
            
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email or Password wrong!");
                return View(login);
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, login.IsRemember, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "The account is locked out 5 minute!");
                return View(login);
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password wrong!");
                return View(login);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
