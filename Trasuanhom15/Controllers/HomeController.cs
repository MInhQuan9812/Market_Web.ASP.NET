using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trasuanhom15.Models;

namespace Trasuanhom15.Controllers
{
    public class HomeController : Controller
    {
        private TrasuaDBEntities1 db = new TrasuaDBEntities1();
        public ActionResult Index()
        {
            var products = db.Products.Where(p => p.Price>53000);
            return View(products.ToList());
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