using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookshop.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        bookshopDB storeDB = new bookshopDB();
        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var orders = new order();
            TryUpdateModel(orders);
            try
            {
                orders.Username = User.Identity.Name;
                orders.OrderDate = DateTime.Now;
                storeDB.order.Add(orders);
                storeDB.SaveChanges();
                var carts = shoppingcart.GetCart(this.HttpContext);
                carts.CreateOrder(orders);
                return RedirectToAction("Complete", new { id = orders.OrderId });
            } catch
            {
                return View(orders);
            }
        }
        public ActionResult Complete(int id)
        {
            bool isValid = storeDB.order.Any(o => o.OrderId == id && o.Username == User.Identity.Name);
            if(isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}