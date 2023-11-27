using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bnebookstore_dbfirstmvcproject.Models;
using System.Data.Entity;
using System.Web.Mvc.Html;
using System.Web.WebPages.Html;

namespace bnebookstore_dbfirstmvcproject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        bnebookstoreEntities db = new bnebookstoreEntities();
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = db.Employees.Where(x => x.EmployeeNo == id).FirstOrDefault();
            db.SaveChanges();
            return View(result);

        }

        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified; db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();

            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var result = db.Employees.Find(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {

            var result = db.Employees.Find(id);
            db.Employees.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
