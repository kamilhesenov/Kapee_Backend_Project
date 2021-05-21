using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Kapee.Areas.Admin.Controllers
{
    [Area("UserPanel")]
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
