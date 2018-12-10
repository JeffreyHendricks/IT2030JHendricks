using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalEventApplication.Models;
using FinalEventApplication.Models.ViewModels;

namespace FinalEventApplication.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            OrderCart cart = OrderCart.GetCart(this.HttpContext);

            OrderViewModel vm = new OrderViewModel()
            {
                OrderItems = cart.GetOrderItems()

            };
            return View(vm);
        }

        // GET: Order
        public ActionResult AddOrder(int id)
        {
            OrderCart cart = OrderCart.GetCart(this.HttpContext);
            cart.AddToCart(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveOrder()
        {
            return View();
        }

        // GET: Order
        public ActionResult Register()
        {
            return View();
        }

        // GET: Order
        public ActionResult OrderSummary()
        {
            return View();
        }
    }
}