using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FinalEventApplication.Models;


namespace FinalEventApplication.Controllers
{
    public class HomeController : Controller
    {
       private FinalEventApplicationDBContext db = new FinalEventApplicationDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LastMinuteDeals()
        {
            var events = GetLastMinuteDeals();
            return PartialView("LastMinuteDeals", events);
        }

        private List<Event> GetLastMinuteDeals()
        {

            var date2 = DateTime.Now.AddDays(2);
            var events = db.Events.Where(e => e.EndDate <= date2).ToList();
            return events;
        }

        public ActionResult EventSearch(string q, string w)
        {
            var newEvents = GetEvent(q, w);
            return PartialView(newEvents);
        }

        private List<Event> GetEvent(string titleString, string locationString)
        {
            if(titleString != "" && locationString == "")
            {
                return db.Events.Where(a => a.Title.StartsWith(titleString) || a.EventTypeTitle.StartsWith(titleString)).ToList();
            }else if(titleString == "" && locationString != "")
            {
                return db.Events.Where(a => a.Location.StartsWith(locationString) || a.City.StartsWith(locationString)).ToList();
            }else if(titleString != "" && locationString != "")
            {
                return db.Events.Where(a => a.Title.StartsWith(titleString) && a.Location.StartsWith(locationString) || a.Title.StartsWith(titleString) && a.EventTypeTitle.StartsWith(locationString)).ToList();
            }

            return db.Events.ToList();
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
    }
}