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
        
        public string Add_()
        {
            
            db.Add(new User { UserId = "Lushuwen", Password = "Lushuwen" });
            db.SaveChanges();
            return "";
        }


        public IActionResult Index()
        {
            return View();
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