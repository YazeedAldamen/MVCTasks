using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task_31_jan.Controllers
{
    public class YazeedController : Controller
    {
        // GET: Yazeed
        public ActionResult Index()
        {
            return RedirectToRoute("Default", new { controller ="Default", action = "image" });
        }

        public string Name() {
        //RedirectToRoute("index");
        return "My Name is Yazeed";
        }

        public FileResult File() {

            var path = Server.MapPath("~/images/juice.png");
                return File(path,"png");
           
        }

        public ContentResult Age(){
            int age = 24;
            return Content("My age is: " + age.ToString());
        }
    }
}