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
        private readonly UniversityContext db;
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
            var mGroups = db.Groups
                .Include(x => x.Course)
                .Where(x => x.group_ID == id);            
            if (mGroups == null)
            {
                ViewBag.StatusRemoveGroup = 0;
            }
            return View(mGroups);
        }
        [HttpGet]
        public IActionResult showStudents(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.STUDENT_ID = id;
            var mStudents = db.Students
                .Include(x => x.Group)
                .Where(x => x.Group.group_ID == id);
            return View(mStudents);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet()]
        public IActionResult changeNameOfGroup(int? idGroup, int? idCourse)
        {
            ViewBag.HTMLGroupName = (HttpContext.Request.Query["groupName"]).ToString();
            return View();
        }

        [HttpPost]
        public string changeNameOfGroup(Group group)
        {
            string result = "";
            string mGroupId = HttpContext.Request.Query["mGroup"].ToString();
            string mCourseId = HttpContext.Request.Query["mCourse"].ToString();
            try
            {
                var mGroups = db.Groups
                    .Include(x => x.Course)
                    .Where(x => x.group_ID == Convert.ToInt32(mGroupId) && x.Course.course_ID == Convert.ToInt32(mCourseId)).FirstOrDefault();
                mGroups.name = group.name;
                result = "Имя группы обновлено";
            }
            catch (SqlException ex)
            {
                result = "Ошибка запроса. Имя группы не обновлено";
            }
            db.SaveChanges();
            return result;
        }

        [HttpGet()]
        public IActionResult changeNameOfStudent(int? idStudent)
        {
            @ViewBag.HTMLStudentsFirstName = (HttpContext.Request.Query["studentName"]).ToString();
            @ViewBag.HTMLStudentsLastName = (HttpContext.Request.Query["studentLastName"]).ToString();
            return View();
        }

        [HttpPost]
        public string changeNameOfStudent(Student student)
        {
            string result = "";
            string mStudentId = HttpContext.Request.Query["student_id"].ToString();
            try
            {
                var mStudent = db.Students
                    .Where(x => x.student_ID == student.student_ID)
                    .FirstOrDefault();
                mStudent.first_Name = student.first_Name;
                mStudent.last_Name = student.last_Name;
                db.SaveChanges();
                result = "Данные студента обновлены";
            }
            catch (SqlException ex)
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
            var allRows = db.Students
                .Where(s => s.Group.group_ID == groupId)
                .ToList();
            count = allRows.Count;
            if (count == 0)
            {
                result = "Невозможно удалить группу. Число студентов 0.";
            }
            else
            {
                try
                {
                    var RemoveStudent = db.Students.Where(x => x.Group.group_ID == groupId).ToList();
                    var RemoveGroup = db.Groups.Where(x => x.group_ID == groupId);
                    db.Students.RemoveRange(RemoveStudent);
                    db.Groups.RemoveRange(RemoveGroup);
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
    }
}
