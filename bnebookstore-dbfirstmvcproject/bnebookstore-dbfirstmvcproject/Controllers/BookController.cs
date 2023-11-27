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
    public class BookController : Controller
    {
        // GET: Book
        bnebookstoreEntities db = new bnebookstoreEntities();
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Book book)
        {
            try
            {
                db.Books.Add(book);
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
            var result = db.Books.Where(x => x.BookNo == id).FirstOrDefault();
            db.SaveChanges();
            return View(result);

        }

        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                db.Entry(book).State = System.Data.Entity.EntityState.Modified; db.SaveChanges();
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
            var result = db.Books.Find(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(int id, Book book)
        {

            var result = db.Books.Find(id);
            db.Books.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
     
 
}

//public ActionResult Edit(int Id)
//{
//    //here, get the student from the database in the real application

//    //getting a student from collection for demo purpose
//    var std = studentList.Where(s => s.StudentId == Id).FirstOrDefault();

//    return View(std);
//}

//[HttpPost]
//public ActionResult Edit(Student std)
//{
//    //update student in DB using EntityFramework in real-life application

//    //update list by removing old student and adding updated student for demo purpose
//    var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
//    studentList.Remove(student);
//    studentList.Add(std);

//    return RedirectToAction("Index");
//}