using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookshop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult PostLogin(string username, string password)
        {
            if (username == "root" && password == "123")
            {
                var cookie = new HttpCookie("isauth", "true");
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "bookshopDB");
            }
            return View();
        }

    }
}