using HTTP5101_Cumulative1_UditeshJha.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTTP5101_Cumulative1_UditeshJha.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teacher/List
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        // GET: Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher Teacher = controller.FindTeacher(id);
            return View(Teacher);
        }

        // GET: Teacher/DeleteTeacherConfirm/{id}
        public ActionResult DeleteConfirmTeacher(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher Teacher = controller.FindTeacher(id);
            return View(Teacher);
        }

        // GET: Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        // GET: Teacher/New
        public ActionResult New()
        {
            return View();
        }

        // GET: Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber,
            DateTime HireDate, decimal Salary)
        {
            /*if (ModelState.IsValid)
            {*/
                //Identify that this method is running
                // Identify input provided from the form
                Debug.WriteLine("I have access to the create method.");
                Debug.WriteLine(TeacherFname);
                Debug.WriteLine(TeacherLname);
                Debug.WriteLine(EmployeeNumber);
                Debug.WriteLine(HireDate);
                Debug.WriteLine(Salary);
                Teacher newTeacher = new Teacher();
                newTeacher.TeacherFname = TeacherFname;
                newTeacher.TeacherLname = TeacherLname;
                if (newTeacher.TeacherFname == null || newTeacher.TeacherLname == null)
                    {
                        return RedirectToAction("New");
                    }
                newTeacher.EmployeeNumber = EmployeeNumber;
                newTeacher.HireDate = HireDate;
                newTeacher.Salary = Salary;

                TeacherDataController controller = new TeacherDataController();
                controller.AddTeacher(newTeacher);     
                return RedirectToAction("List");
            //}
        }

    }
}