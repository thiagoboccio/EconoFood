using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EconoFood.Services;

namespace EconoFood.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GotoHome()
        //{
        //    return View();
        //}

        public ActionResult GotoHome(EconoFood.Web.Models.HomeModel model)
        {
            return View();
        }
    }
}