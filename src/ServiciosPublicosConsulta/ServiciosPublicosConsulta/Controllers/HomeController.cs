using ServiciosPublicosConsulta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiciosPublicosConsulta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ServiciosPublicosDbContext db = new ServiciosPublicosDbContext();
            var logs = db.Logs;
            return View(logs);
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