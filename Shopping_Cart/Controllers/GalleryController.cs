using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Models;
using System.Data;

namespace Shopping_Cart.Controllers
{
    public class GalleryController : Controller
    {
        private readonly MyDbContext db;

        public GalleryController(MyDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            products = db.Product.ToList();

            ViewData["products"] = products;
            return View();
        }
    }
}
