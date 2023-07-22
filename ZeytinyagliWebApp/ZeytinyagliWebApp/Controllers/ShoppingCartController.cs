using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeytinyagliWebApp.Models;

namespace ZeytinyagliWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        OliveOilDBModel db = new OliveOilDBModel();
        // GET: ShoppingCart
        public ActionResult Add(int? id)
        {
            Product product = db.Products.Find(id);
            List<SessionCartProduct> SessionCart;
            bool isadded = false;
            if (Session["shoppingCart"] != null)
            {
                SessionCart = (List<SessionCartProduct>)Session["shoppingCart"];

                foreach (SessionCartProduct item in SessionCart)
                {
                    if (item.Product_ID == product.ID)
                    {
                        item.Quantity = item.Quantity + 1;
                        isadded = true;
                    }
                }
                if (isadded == false)
                {
                    SessionCartProduct scp = new SessionCartProduct();
                    scp.ProductName = product.Name;
                    scp.Product_ID = product.ID;
                    scp.Quantity = 1;
                    scp.ThumbImage = product.ListImage;
                    SessionCart.Add(scp);
                }
            }
            else
            {
                SessionCart = new List<SessionCartProduct>();
                SessionCartProduct scp = new SessionCartProduct();
                scp.ProductName = product.Name;
                scp.Product_ID = product.ID;
                scp.Quantity = 1;
                scp.ThumbImage = product.ListImage;
                SessionCart.Add(scp);
            }
            Session["shoppingCart"] = SessionCart;
            return RedirectToAction("Index","Home");
        }
    }
}