using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookshop.Controllers
{
    //[Authorize(Roles ="103623003@qq.com")]
    public class StoreManagerController : Controller
    {
        bookshopDB storeDB = new bookshopDB();
        // GET: StoreManager
        public ActionResult Index()
        {
            var books = storeDB.book.Include("genre").Include("author").ToList();
            return View(books);
        }


        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.genre = storeDB.genre.OrderBy(g => g.Name).ToList();
            ViewBag.author = storeDB.author.OrderBy(a => a.Name).ToList();
            var books = new book();
            return View(books);
        }

        // POST: StoreManager/Create
        [HttpPost]
        public ActionResult Create(book books)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                storeDB.book.Add(books);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.genre = storeDB.genre.OrderBy(g => g.Name).ToList();
            ViewBag.author = storeDB.author.OrderBy(a => a.Name).ToList();
            return View(books);
            
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.genre = storeDB.genre.OrderBy(g => g.Name).ToList();
            ViewBag.author = storeDB.author.OrderBy(a => a.Name).ToList();
            book books = storeDB.book.Single(a => a.Id == id);
            return View(books);
        }

        // POST: StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var books = storeDB.book.Find(id);
           if(TryUpdateModel(books))
            {
                // TODO: Add update logic here
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                ViewBag.genre = storeDB.genre.OrderBy(g => g.Name).ToList();
                ViewBag.author = storeDB.author.OrderBy(a => a.Name).ToList();
                return View(books);
            }
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int id)
        {
            var books = storeDB.book.Find(id);
            return View(books);
        }

        // POST: StoreManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var books = storeDB.book.Find(id);
            storeDB.book.Remove(books);
            storeDB.SaveChanges();
            return View("Deleted");
        }
    }
}
