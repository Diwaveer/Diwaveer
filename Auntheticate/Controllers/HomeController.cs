using Auntheticate.Areas.Identity.Data;
using Auntheticate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mono.TextTemplating;
using System.Diagnostics;

namespace Auntheticate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _databaseContext;
        public HomeController(ILogger<HomeController> logger,DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;

        }

        public IActionResult Index()
        {
            var categories = _databaseContext.Categories.ToList();
            var products = new List<Product>();

            categories.Add(new Category()
            {
                Id = 0,
                CategoryName = "--Select Category--"
            });
            products.Add(new Product()
            {
                Id = 0,
                Name = "--Select Product--"

            });

            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            ViewBag.Products = new SelectList(products, "Id", "Name");
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


        public JsonResult GetProductByCategoryId(int categoryId)
        {
            List<Product> products = _databaseContext.Products.Where(s => s.CategoryId == categoryId).ToList();
            return Json(products.Select(s => new { id = s.Id, text = s.Name }));
            //return Json(_databaseContext.Products.Where(u => u.CategoryId == categoryId).ToList());
        }
        



    }
}
