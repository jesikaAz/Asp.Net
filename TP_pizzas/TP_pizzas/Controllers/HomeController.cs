using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TP_pizzas.Controllers
{
    public class HomeController : Controller
    {
        //private Pizza pizza;
        
        public ActionResult Index()
        {
            return View();
        }

    }
}
