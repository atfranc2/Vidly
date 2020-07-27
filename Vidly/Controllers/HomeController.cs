using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{   
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customers()
        {
            return Redirect("/Customers");
        }

        public ActionResult Movies()
        {
            ViewBag.Message = "Your contact page.";

            return Redirect("/Movies");
        }
    }
}