using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeytinyagliWebApp.Areas.ManagerPanel.Filters;
using ZeytinyagliWebApp.Models;

namespace ZeytinyagliWebApp.Areas.ManagerPanel.Controllers
{
    [ManagerLoginFilter]
    public class DefaultController : Controller
    {
        OliveOilDBModel db = new OliveOilDBModel();
        public ActionResult Index()
        {
            ViewBag.CategoryCount = db.Categories.Count(x => x.IsDeleted == false);
            ViewBag.ProductCount = db.Products.Count(x => x.IsDeleted == false);
            return View();
        }
    }
}