using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeytinyagliWebApp.Areas.ManagerPanel.Filters;
using ZeytinyagliWebApp.Models;

namespace ZeytinyagliWebApp.Areas.ManagerPanel.Controllers
{
    [ManagerLoginFilter]
    public class ProductController : Controller
    {
        private OliveOilDBModel db = new OliveOilDBModel();
        private bool IsListImageValid = false;
        private bool IsImageValid = false;

        // GET: ManagerPanel/Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: ManagerPanel/Product/Create
        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase ListeResim, HttpPostedFileBase Resim)
        {
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name");
            if (ModelState.IsValid)
            {
                try
                {
                    if (ListeResim != null)
                    {
                        FileInfo fi = new FileInfo(ListeResim.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png")
                        {
                            string name = Guid.NewGuid().ToString() + fi.Extension;
                            model.ListImage = name;
                            ListeResim.SaveAs(Server.MapPath("~/Assets/ProductImages/Thumb/" + name));
                            IsListImageValid = true;
                        }
                    }
                    else
                    {
                        model.ListImage = "None.png";
                    }
                    if (Resim != null)
                    {
                        FileInfo fi = new FileInfo(Resim.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png")
                        {
                            string name = Guid.NewGuid().ToString() + fi.Extension;
                            model.Image = name;
                            Resim.SaveAs(Server.MapPath("~/Assets/ProductImages/" + name));
                            IsImageValid = true;
                        }
                    }
                    else
                    {
                        model.Image = "None.png";
                    }
                    if (IsImageValid && IsListImageValid)
                    {
                        db.Products.Add(model);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Hata = "Dosya Formatı Hatalı";
                        return View();
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Hata = "Eklerken Bir Hata Oluştu";
                    return View();
                }
            }
           
            return View(model);
        }

        // GET: ManagerPanel/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerPanel/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerPanel/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerPanel/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
