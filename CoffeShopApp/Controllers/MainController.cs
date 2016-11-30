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
        public ActionResult Admin()
        {
            ViewBag.ProductList = ShowList();
            return View();
        }
        public ActionResult Delete(string product)
        {
            CoffeeShopDBEntities2 dbContext = new CoffeeShopDBEntities2();
            Product toDelete = dbContext.Products.Find(product);  //Find uses primary key

            //check for null
            dbContext.Products.Remove(toDelete);  //Remove = forever
            dbContext.SaveChanges(); //changes db

            ViewBag.productList = ShowList();
            return View();
        }
        public ActionResult InsertProduct(Product p)
        {
            CoffeeShopDBEntities2 dbContext = new CoffeeShopDBEntities2();
            dbContext.Products.Add(p);
            dbContext.SaveChanges();
            ViewBag.productList = ShowList();
            return View("Admin");
        }
        public ActionResult AddProduct()
        {

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
            ViewBag.Message = "Thanks, " + data.Uname + ".\n We're sending an email to " + data.Email + ".";
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
            ViewBag.Cart = cart.Values.ToList();
            ViewBag.productList = ShowList();

            return View("Index");
        }

        public ActionResult Search(string product)
        {
            CoffeeShopDBEntities2 dbContext = new CoffeeShopDBEntities2();
            

            //check for null

            List<Product> Found = new List<Product>();
            Found.Add(dbContext.Products.Find(product));
            ViewBag.productList = Found;
            return View("Index");
        }

        public ActionResult CalculateLineTotal(string product)
        {

            CoffeeShopDBEntities2 dbContext = new CoffeeShopDBEntities2();
            //dbContext.Entry(Product LineTotal)




            //Dictionary<string, Product> cart = (Dictionary<string, Product>)Session["cart"];
            //ViewBag.cart = cart.Values.ToList();

            ////string[] cartArray = new string[];

            //double lineTotal = cart[product].Qty * cart[product].Price;

            //double[] cartPrice = cart.ElementAt(1);

            //new double[cart.Count];
            //double[] cartQty = new double[cart.Count];
            //for (int i = 1; i < cart.Count; i++)
            //{
            //    cartPrice[i] = cart[product].Price;
            //}
            //cartArray = { cart[product].Price, cart[product].Qty, lineTotal };

            return View();
        }

    }
}
