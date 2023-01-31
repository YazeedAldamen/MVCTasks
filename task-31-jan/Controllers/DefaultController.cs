using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task_31_jan.Controllers
{
    public class DefaultController : Controller
    {
      

        // GET: Default
        public string image()
        {
            return ("<a download='juice.png' href='../images/juice.png'><img src='../images/juice.png'/></a>");
        }
 
        public string AboutUs(){
            return "AboutUs";
        }
        public string ContactUs()
        {
            return "ContactUs";
        }


    }
}