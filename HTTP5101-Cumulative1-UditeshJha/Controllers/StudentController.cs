using HTTP5101_Cumulative1_UditeshJha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTTP5101_Cumulative1_UditeshJha.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/List
        public ActionResult ListStudent()
        {
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> students = controller.ListStudents();
            return View(students);
        }

        // GET: Student/Show/{id}
        public ActionResult ShowStudent(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student student = controller.FindStudent(id);
            return View(student);
        }
    }
}