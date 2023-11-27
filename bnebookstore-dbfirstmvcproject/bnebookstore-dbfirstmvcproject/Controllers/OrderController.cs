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
    public class OrderController : Controller
    {
        // GET: Order
        bnebookstoreEntities db = new bnebookstoreEntities();
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Order order)
        {
            try
            {
                db.Orders.Add(order);
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
            var result = db.Orders.Where(x => x.OrderNo == id).FirstOrDefault();
            db.SaveChanges();
            return View(result);

        }

        [HttpPost]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                db.Entry(order).State = System.Data.Entity.EntityState.Modified; db.SaveChanges();
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
            var result = db.Orders.Find(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(int id, Order order)
        {

            var result = db.Orders.Find(id);
            db.Orders.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
