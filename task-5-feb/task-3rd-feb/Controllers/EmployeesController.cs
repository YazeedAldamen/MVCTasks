using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using task_3rd_feb.Models;

namespace task_3rd_feb.Controllers
{
    public class EmployeesController : Controller
    {
        private Entities db = new Entities();

        // GET: Employees
        public ActionResult Index()
        {
            var result = db.Employees.ToList();
            return View(result);
        }

        public ActionResult Search(string option, string Search)
        {
            if (option == "First_Name")
            {
                var result = db.Employees.Where(x => x.First_Name.Contains(Search)).ToList();
                return View("Index", result);
            }
            else if (option == "Last_Name")
            {
                var result = db.Employees.Where(x => x.Last_Name.Contains(Search)).ToList();
                return View("Index", result);
            }
            else if (option == "Email")
            {
                var result = db.Employees.Where(x => x.Email.Contains(Search)).ToList();
                return View("Index", result);
            }
            else if (option == "Age"){
                var result = db.Employees.Where(x => x.Age.ToString() == Search).ToList();
                return View("Index", result);

            }
            else{
                return View("Index");
            }
           
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Email,Phone,Age,Job_Title,Gender,Images,CV")] Employee employee, HttpPostedFileBase Images, HttpPostedFileBase CV)
        {
            if (Images != null)
            {
                string _FileName = Path.GetFileName(Images.FileName);
                string _path = Path.Combine(Server.MapPath("~/images"), _FileName);
                Images.SaveAs( _path);
                employee.Images = _FileName;

            }
            if (CV != null)
            {
                string _FileName = Path.GetFileName(CV.FileName);
                string _path = Path.Combine(Server.MapPath("~/documents"), _FileName);
                CV.SaveAs( _path);
                employee.CV = _FileName;
            }
            
            db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Email,Phone,Age,Job_Title,Gender,Images,CV")] Employee employee, HttpPostedFileBase Images, HttpPostedFileBase CV)
        {
            if (Images != null)
            {
                string _FileName = Path.GetFileName(Images.FileName);
                string _path = Path.Combine(Server.MapPath("~/images"), _FileName);
                Images.SaveAs(_path);
                employee.Images = _FileName;

            }

            if (CV != null)
            {
                string _FileName = Path.GetFileName(CV.FileName);
                string _path = Path.Combine(Server.MapPath("~/documents"), _FileName);
                CV.SaveAs(_path);
                employee.CV = _FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public FileResult Image(string Images)
        {

            var path = Server.MapPath($"~/images/{Images}");

            return File(path, "png");

        }

        public FileResult cvUpload(string document){
            var path = Server.MapPath($"~/documents/{document}");
            return File(path,"pdf");
        }
    }
}
