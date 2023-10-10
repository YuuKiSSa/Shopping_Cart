using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Models;
using System.Diagnostics;

namespace Shopping_Cart.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly MyDbContext db;

        public LoginController(ILogger<LoginController> logger, MyDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Validate([FromBody] _User user)
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