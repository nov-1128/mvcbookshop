using System.Linq;
using System.Web.Mvc;
using bookshop;

namespace bookshop.Controllers
{
    public class shoppingcartController : Controller
    {
        bookshopDB storeDB = new bookshopDB();
        // GET: shoppingcart
        public ActionResult Index()
        {
            var carts = shoppingcart.GetCart(this.HttpContext);
            var viewModels = new scartviewmodel
            {
                cartItems = carts.GetCartItems(),
                CartTotal = carts.GetTotal()
            };
            return View(viewModels);
        }

        public ActionResult AddtoCart(int id)
        {
            var addbooks = storeDB.book.Single(b => b.Id == id);
            var cart = shoppingcart.GetCart(this.HttpContext);
            cart.AddToCart(addbooks);
            return RedirectToAction("Index");
        }
      [HttpPost]
      public ActionResult RemoveFromCart(int id)
        {
            var carts = shoppingcart.GetCart(this.HttpContext);
            string bookName = storeDB.cart.Single(i => i.RecordId == id).book.Title;
            int itemCount = carts.RemoveFromCart(id);
            var results = new scrviewmodel
            {
                Message = Server.HtmlEncode(bookName) + "已经从购物车中删除。",
                CartTotal = carts.GetTotal(),
                CartCount = carts.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var carts = shoppingcart.GetCart(this.HttpContext);
            ViewData["CartCount"] = carts.GetCount();
            return PartialView("CartSummary");
        }


    }
}
