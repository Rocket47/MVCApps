using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCApps.Models;
using Microsoft.EntityFrameworkCore;



namespace MVCApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UniversityContext db;

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
        [HttpGet]
        public IActionResult showStudents(int? id) 
        {
            if (id == null) return RedirectToAction("Index");  
            ViewBag.STUDENT_ID = id;          
            return View(db.Students.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public string changeNameForGroup(Group name) {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            db.Groups.FromSqlRaw("UPDATE GROUPS" +
                    "SET GROUPS.NAME = 'Hello World!' WHERE (GROUPS.GROUP_ID & GROUPS.COURSE_ID = 1)");
            db.SaveChanges();
            return "База Данных обновлена!!!";
        }
    }
}