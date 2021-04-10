using HTTP5101_Cumulative1_UditeshJha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTTP5101_Cumulative1_UditeshJha.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        // GET: Class/ListClass
        public ActionResult ListClass()
        {
            ClassDataController controller = new ClassDataController();
            IEnumerable<Class> classes = controller.ListClasses();
            return View(classes);
        }

        // GET: Class/ShowClass/{id}
        public ActionResult ShowClass(int id)
        {
            ClassDataController controller = new ClassDataController();
            Class cl = controller.FindClass(id);
            return View(cl);
        }
    }
}