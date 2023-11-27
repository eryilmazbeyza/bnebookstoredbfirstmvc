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
    public class StoreController : Controller
    {
        // GET: Store

            bnebookstoreEntities db = new bnebookstoreEntities();
            public ActionResult Index()
            {
                return View(db.Stores.ToList());
            }

            public ActionResult New()
            {
                return View();
            }
            [HttpPost]
            public ActionResult New(Store store)
            {
                try
                {
                    db.Stores.Add(store);
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
                var result = db.Stores.Where(x => x.StoreNo == id).FirstOrDefault();
                db.SaveChanges();
                return View(result);

            }

            [HttpPost]
            public ActionResult Edit(int id, Store store)
            {
                try
                {
                    db.Entry(store).State = System.Data.Entity.EntityState.Modified; db.SaveChanges();
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
                var result = db.Stores.Find(id);
                return View(result);
            }

            [HttpPost]
            public ActionResult Delete(int id, Store store)
            {

                var result = db.Stores.Find(id);
                db.Stores.Remove(result);
                db.SaveChanges();
                return RedirectToAction("Index");

            }




    }
}
