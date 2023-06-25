using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeytinyagliWebApp.Areas.ManagerPanel.Model;
using ZeytinyagliWebApp.Models;

namespace ZeytinyagliWebApp.Areas.ManagerPanel.Controllers
{
    public class LoginController : Controller
    {
        OliveOilDBModel db = new OliveOilDBModel();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ManagerLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                int count = db.Managers.Count(x => x.Mail == model.Mail && x.Password == model.password);
                if (count > 0)
                {
                    Manager m = db.Managers.First(x => x.Mail == model.Mail && x.Password == model.password);
                    if (m.IsActive)
                    {
                        Session["manager"] = m;
                        return RedirectToAction("Index", "Default");
                    }
                    else
                    {
                        TempData["mesaj"] = "Hesabınız askıya alınmıştır";
                    }
                }
                else
                {
                    TempData["mesaj"] = "Kullanıcı Bulunamadı";
                }
            }
            return View(model);
        }
    }
}