using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DEMO_1.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration =20)]
        public string ReturnTime()
        {
            return DateTime.Now.ToString();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return RedirectToAction("/NewEmployee/GettAll");
        }
        public ActionResult GettAll()
        {
            ViewBag.Message = "Your GatAll page.";

            return RedirectToAction("MVC_DEMO_1.Controllers.Employee.GettAll") ;
        }
    }
}