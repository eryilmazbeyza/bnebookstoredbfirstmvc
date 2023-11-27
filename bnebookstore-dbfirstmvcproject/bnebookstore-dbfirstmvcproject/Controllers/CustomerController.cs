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
    public class CustomerController : Controller
    {
        // GET: Customer
        bnebookstoreEntities db = new bnebookstoreEntities();
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
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
            var result = db.Customers.Where(x => x.CustomerNo == id).FirstOrDefault();
            db.SaveChanges();
            return View(result);

        }

        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified; db.SaveChanges();
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
            var result = db.Customers.Find(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {

            var result = db.Customers.Find(id);
            db.Customers.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
