
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace bookshop.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        bookshopDB storeDB = new bookshopDB();
        public ActionResult Index()
        {
           
            var genres = storeDB.genre.ToList();
            
            return View(genres);
        }
        public ActionResult AllBook(int id)
        {

            var genreModel = storeDB.genre.Include("book").Single(g => g.GenreId == id);
            return View(genreModel);
        }
        public ActionResult Details(int id)
        {
            var book = storeDB.book.Find(id);
            return View(book);
        }
    }
}