using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CoffeShopApp.Models;


namespace CoffeShopApp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProcessSignup(UserData data)
        {
            ViewBag.Message = "Thanks, " + data.Uname + ".\n We're sending an email to "+ data.Email+".";
                return View("Index");
            //return Redirect("https://www.google.com");
        }
        public ActionResult OrderDonuts()
        {
            List<string> Cart = new List<string>();
            Cart.Add("donut");
            ViewBag.Message("One donut added to cart.");
            return View();
        }
        public ActionResult CountDonut(ref int donutN)
        {
            if (Session["donutN"] == null)
                Session.Add("donutN", 0);
            donutN = (int)Session["donutN"];
            donutN++;
            Session["donutN"] = donutN;

            ViewBag.counter = donutN;
            return View();

        }
        public ActionResult Order(string product)
        {
            if(Session["cart"] ==null)
            {
                Dictionary<string, Product> tempCart = new Dictionary<string, Product>();
                Session["cart"] = tempCart;
             }
            Dictionary<string, Product> cart = (Dictionary<string, Product>)Session["cart"];

            if (!cart.ContainsKey(product))
               {
                cart.Add(product, new Product(product, 1, 1));
            }
            else
            {
                cart[product].Quantity += 1;
            }
            ViewBag.cart.Values.ToList();
            return View("Index");
        }

    }
}