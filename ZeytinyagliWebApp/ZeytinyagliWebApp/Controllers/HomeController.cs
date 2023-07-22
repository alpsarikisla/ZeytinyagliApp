using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeytinyagliWebApp.Models;

namespace ZeytinyagliWebApp.Controllers
{
    public class HomeController : Controller
    {
        OliveOilDBModel db = new OliveOilDBModel();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

       
    }
}