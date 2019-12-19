using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCApps.Models;

namespace MVCApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UniversityContext db;

        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }

        public HomeController(UniversityContext context) 
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

    [HttpGet]
        public IActionResult showGroups(int? id) 
        {
            if (id == null) return RedirectToAction("Index");  
            ViewBag.GROUP_ID = id;          
            return View(db.Groups.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
