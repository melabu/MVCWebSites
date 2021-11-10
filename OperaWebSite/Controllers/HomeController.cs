using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperaWebSite.Filters;

namespace OperaWebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [MyFilterAction]
        public ActionResult Index()
        {
            ViewBag.Fecha = DateTime.Now;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}