using Dropdown.Data;
using Dropdown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Dropdown.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly DatabaseContext _context;
        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var states = _context.States.Include(s => s.Districts).ToList();
            return View(states);
            
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

        public JsonResult GetDistricts(int stateId)
        {
            var districts = _context.Districts.Where(d => d.StateId == stateId).ToList();
            return Json(districts);
        }




    }
}
