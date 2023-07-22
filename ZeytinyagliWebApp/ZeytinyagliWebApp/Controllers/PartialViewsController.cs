using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeytinyagliWebApp.Models;

namespace ZeytinyagliWebApp.Controllers
{
    public class PartialViewsController : Controller
    {
        OliveOilDBModel db = new OliveOilDBModel();
        // GET: PartialViews
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CategoryMenu()
        {
            return PartialView(db.Categories.Where(x => x.IsActive == true && x.IsDeleted == false));
        }

        public PartialViewResult _ProductList()
        {
            return PartialView(db.Products.Where(x=> x.IsActive == true && x.IsDeleted == false && x.IsRecent == false));
        }
        public PartialViewResult _RecentProductList()
        {
            return PartialView(db.Products.Where(x => x.IsActive == true && x.IsDeleted == false && x.IsRecent == true));
        }
        public PartialViewResult _CartpartialMenuView()
        {
            List<SessionCartProduct> cart = new List<SessionCartProduct>();
            if (Session["shoppingCart"] != null)
            {
                cart = (List<SessionCartProduct>)Session["shoppingCart"];
            }
            ViewBag.Count = cart.Count();
            return PartialView();
        }
    }
}