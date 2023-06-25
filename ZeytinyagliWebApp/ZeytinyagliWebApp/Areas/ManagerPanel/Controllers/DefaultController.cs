using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeytinyagliWebApp.Areas.ManagerPanel.Filters;

namespace ZeytinyagliWebApp.Areas.ManagerPanel.Controllers
{
    [ManagerLoginFilter]
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}