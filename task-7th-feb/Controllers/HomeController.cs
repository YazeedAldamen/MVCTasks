using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using task_7th_feb.Models;

namespace task_7th_feb.Controllers
{
    
    public class HomeController : Controller
    {
        private Entities db = new Entities();
        public ActionResult Index()
        {
            var result = db.Menus.ToList();
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}