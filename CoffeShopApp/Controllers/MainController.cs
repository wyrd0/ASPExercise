using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeShopApp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProcessSignup(string UName, string Email)
        {
            ViewBag.Message = "Thanks, " + UName + ".\n We're sending an email to "+ Email+".";
                return View("Index");
            //return Redirect("https://www.google.com");
        }
    }
}