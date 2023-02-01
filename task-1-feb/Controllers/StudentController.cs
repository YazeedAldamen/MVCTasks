using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task_1_feb.Models;

namespace task_1_feb.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult info() {
            
            Student student = new Student();
            Student student2 = new Student();
            student.ID = 1;
            student.Name = "Yazeed";
            student.Major = "Mechanical Engineering";
            student.Faculity = "Faculity OF Engineering";
            student2.ID = 2;
            student2.Name = "Malek";
            student2.Major = "Computer Science";
            student2.Faculity = "Faculity OF Information Technology";

            List<Student> students = new List<Student>();
            students.Add(student);
            students.Add(student2);

            return View(students);
        }
    }
}