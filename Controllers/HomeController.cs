using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCApps.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer;

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

        [HttpGet()]
        public IActionResult changeNameOfGroup(int? idGroup, int? idCourse) {                    
            return View();
        }

        [HttpPost]
        public string changeNameOfGroup(Group group) 
        {    
            string result = "";
            string mGroupId = HttpContext.Request.Query["mGroup"].ToString();           
            string mCourseId = HttpContext.Request.Query["mCourse"].ToString();
            try {
            db.Database.ExecuteSqlRaw("UPDATE GROUPS" +
                    " SET GROUPS.NAME =" + $"'{group.name}'" + $" WHERE (GROUPS.GROUP_ID = {mGroupId} AND GROUPS.COURSE_ID = {mCourseId})");
            result = "Имя группы обновлено";
            }
            catch (SqlException  ex) {
                result = "Ошибка запроса. Имя группы не обновлено";
            }
            db.SaveChanges(); 
            return result;           
        }

        [HttpGet()]
        public IActionResult changeNameOfStudent(int? idStudent) {                    
            return View();
        }

        [HttpPost]
        public string changeNameOfStudent(Student student) 
        {    
            string result = "";
            string mStudentId = HttpContext.Request.Query["student_id"].ToString();                      
            try {
            db.Database.ExecuteSqlRaw("UPDATE STUDENTS" +
                    " SET FIRST_NAME =" + $"'{student.first_Name}'" + $" WHERE (STUDENT_ID = {mStudentId})");
             db.Database.ExecuteSqlRaw("UPDATE STUDENTS" +
                    " SET LAST_NAME =" + $"'{student.last_Name}'" + $" WHERE (STUDENT_ID = {mStudentId})");
            result = "Данные студента обновлены";
            }
            catch (SqlException  ex) 
            {
                result = "Ошибка запроса. Имя студента не обновлено";
            }
            db.SaveChanges(); 
            return result;           
        }

        [HttpGet()]
        public string removeGroup(int? idGroup) 
        { 
            string result = "";
            int count = 0;            
            int groupId = Int32.Parse(HttpContext.Request.Query["groupId"]);
            var allRows = db.Students.Where(s => s.group_ID == groupId).ToList();
            count = allRows.Count;
            if (count == 0) 
            {
                result = "Невозможно удалить группу. Число студентов 0.";
            }
            else 
            {   try 
                {
                db.Database.ExecuteSqlRaw($"DELETE FROM STUDENTS WHERE STUDENTS.GROUP_ID = {groupId} DELETE FROM GROUPS WHERE GROUPS.GROUP_ID = {groupId}");
                }
                catch (SqlException ex) 
                {
                    result = "Ошибка запроса. Название группы не обновлено.";
                }
                
            }
           db.SaveChanges();                                       
            return result;
        }    
    }
}
