using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CoffeShopApp.Models;


namespace CoffeShopApp.Controllers
{
    public class MainController : Controller    //mine
    {
        // GET: Main 


        public ActionResult Index()
        {
           ViewBag.ProductList = ShowList();
            return View();
        }

        private static List<Product> ShowList()
        {
            CoffeeShopDBEntities2 dbContext = new CoffeeShopDBEntities2();

            List<Product> productList = dbContext.Products.ToList();
            return productList;
        }

        public ActionResult ProcessSignup(UserData data)
        {
            ViewBag.Message = "Thanks, " + data.Uname + ".\n We're sending an email to "+ data.Email+".";
                return View("Index");
            //return Redirect("https://www.google.com");
        }
       
        public ActionResult Order(string product)
        {
            List<Product> productList = ShowList();
            if (Session["cart"] == null)
            {
                Dictionary<string, Product> tempCart = new Dictionary<string, Product>();
                Session["cart"] = tempCart;
             }
            Dictionary<string, Product> cart = (Dictionary<string, Product>)Session["cart"];

            if (!cart.ContainsKey(product))
            {
                Product productObj = new Product();
                double price = productObj.Price;
                double qty = productObj.Qty;
                double subTotal = cart[product].Qty * cart[product].Price;

                cart.Add(product, new Product(product, price, qty));

            }
            else
            {
                cart[product].Qty += 1;
                double subTotal = cart[product].Qty * cart[product].Price;
            }
            ViewBag.Cart= cart.Values.ToList();
            ViewBag.productList = ShowList();

            return View("Index");
        }

        public ActionResult CalculateLineTotal(string product)
        {
            Dictionary<string, Product> cart = (Dictionary<string, Product>)Session["cart"];
            ViewBag.cart = cart.Values.ToList();

            double lineTotal = cart[product].Qty * cart[product].Price;

            double[] cartArray = new double[cart.Count];
            cartArray = { cart[product].Price, cart[product].Qty, lineTotal };
            
            
            

           
           

                return View();
        }

    }
}