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
            if (db.Courses.ToList().Count == 0) 
            {
                ReseedData();
            }
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

            ViewBag.HTMLGroupName = (HttpContext.Request.Query["groupName"]).ToString();
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
            @ViewBag.HTMLStudentsFirstName = (HttpContext.Request.Query["studentName"]).ToString();
            @ViewBag.HTMLStudentsLastName =  (HttpContext.Request.Query["studentLastName"]).ToString();
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
        public IActionResult removeGroup(int? idGroup) 
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
                result = "Группа удалена.";
                }
                catch (SqlException ex) 
                {
                    result = "Ошибка запроса. Название группы не обновлено.";
                }
                
            }
           var groups = db.Groups.Where(x => x.group_ID == groupId).ToList();
           ViewBag.HTMLStr = result;
           db.SaveChanges();           
           return View(); 
        }

        [HttpPost()]
        public IActionResult removeGroup()
        {
            string groupID = HttpContext.Request.Query["groupId"];
            return RedirectToAction("showGroups", new { id = groupID });
        }

        private void ReseedData() 
        {            
            db.Database.ExecuteSqlRaw("INSERT INTO [COURSES] ([NAME], [DESCRIPTION]) VALUES ('Математика', 'Учим математику')");
            db.Database.ExecuteSqlRaw("INSERT INTO [COURSES] ([NAME], [DESCRIPTION]) VALUES ('Физика', 'Учим физику')");
            db.Database.ExecuteSqlRaw("INSERT INTO [COURSES] ([NAME], [DESCRIPTION]) VALUES ('Статистика', 'Учим статистику')");
            db.Database.ExecuteSqlRaw("INSERT INTO [COURSES] ([NAME], [DESCRIPTION]) VALUES ('Лингвистика', 'Учим лингвистику')");
            db.Database.ExecuteSqlRaw("INSERT INTO [COURSES] ([NAME], [DESCRIPTION]) VALUES ('Тайм менеджмент', 'Учим тайм менеджмент')");
            db.Database.ExecuteSqlRaw("INSERT INTO [GROUPS] ([COURSE_ID], [NAME]) VALUES ('1', 'SR1')");
            db.Database.ExecuteSqlRaw("INSERT INTO [GROUPS] ([COURSE_ID], [NAME]) VALUES ('2', 'SR2')");
            db.Database.ExecuteSqlRaw("INSERT INTO [GROUPS] ([COURSE_ID], [NAME]) VALUES ('3', 'SR3')");
            db.Database.ExecuteSqlRaw("INSERT INTO [GROUPS] ([COURSE_ID], [NAME]) VALUES ('4', 'SR4')");
            db.Database.ExecuteSqlRaw("INSERT INTO [GROUPS] ([COURSE_ID], [NAME]) VALUES ('5', 'SR5')");
            db.Database.ExecuteSqlRaw("INSERT INTO [STUDENTS] ([GROUP_ID], [FIRST_NAME], [LAST_NAME]) VALUES ('1', 'Владимир', 'Добрый')");
            db.Database.ExecuteSqlRaw("INSERT INTO [STUDENTS] ([GROUP_ID], [FIRST_NAME], [LAST_NAME]) VALUES ('2', 'Гоша', 'Злой')");
            db.Database.ExecuteSqlRaw("INSERT INTO [STUDENTS] ([GROUP_ID], [FIRST_NAME], [LAST_NAME]) VALUES ('3', 'Марина', 'Иванова')");
            db.Database.ExecuteSqlRaw("INSERT INTO [STUDENTS] ([GROUP_ID], [FIRST_NAME], [LAST_NAME]) VALUES ('4', 'Зоя', 'Чехова')");
            db.Database.ExecuteSqlRaw("INSERT INTO [STUDENTS] ([GROUP_ID], [FIRST_NAME], [LAST_NAME]) VALUES ('5', 'Арина', 'Долгова')");
            db.SaveChanges();                        
        }
    }
}
