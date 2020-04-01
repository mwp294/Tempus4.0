using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tempus4._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Tempus";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to Find Us";

            return View();
        }

    }
}