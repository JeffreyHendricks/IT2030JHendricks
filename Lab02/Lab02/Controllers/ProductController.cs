using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public String Index()
        {
            return "Product/Index is displayed";
        }

        //GET: Product/Browse/
        public String Browse()
        {
            return "Browse displayed";
        }

        //GET: Product/Details/105
        public String Details(int id)
        {
            return "Details displayed for ID = " + id;
        }

        //GET: Product/Location?zip=44124
        public String Location(int zip)
        {
            string message =
                HttpUtility.HtmlEncode("Location displayed for Zip = " + zip);
            return message;
        }
    }
}