using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballZoneMVC4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Добре дошли в новия информационен портал за статистика Футболна Зона!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Здравейте! Това е страницата с информация за Футболна зона!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Информация за създателят -- Георги Георгиев (a.k.a. Zitrax)";

            return View();
        }
    }
}
