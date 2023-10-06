using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Models;
using System.Diagnostics;

namespace Shopping_Cart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext db;

        public HomeController(ILogger<HomeController> logger, MyDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        public class UU
        {
            public string UserId { get; set; }
            public string Password { get; set; }
        }
        public IActionResult Validate([FromBody] UU user)
        {
            if (ModelState.IsValid)
            {
                User? findUser = db.User.FirstOrDefault(x => x.UserId == user.UserId & x.Password == user.Password);
                if (findUser != null)
                {
                    return Json(new { message = true });
                }
                else return Json(new { message = false });
            }
            return NotFound();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}