using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeytinyagliWebApp.Areas.ManagerPanel.Filters;
using ZeytinyagliWebApp.Models;

namespace ZeytinyagliWebApp.Areas.ManagerPanel.Controllers
{
    //[ManagerLoginFilter]
    public class CategoryController : Controller
    {
        OliveOilDBModel db = new OliveOilDBModel();
        // GET: ManagerPanel/Category
        public ActionResult Index()
        {
            return View(db.Categories.Where(x=> x.IsDeleted == false).ToList());
        }
        public ActionResult AllIndex()
        {
            return View(db.Categories.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)//Nullable integer
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                //return RedirectToAction("Index");
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Category c = db.Categories.Find(id);
            c.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}