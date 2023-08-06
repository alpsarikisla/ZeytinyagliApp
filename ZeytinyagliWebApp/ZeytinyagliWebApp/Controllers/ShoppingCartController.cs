using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ZeytinyagliWebApp.Models;

namespace ZeytinyagliWebApp.Controllers
{
    public class MerchandAPIM
    {
        public string MerchandID { get; set; }
        public string Password { get; set; }
        public string CardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string CCV { get; set; }
        public decimal Price { get; set; }

    }
    public class ShoppingCartController : Controller
    {
        OliveOilDBModel db = new OliveOilDBModel();
        // GET: ShoppingCart

        public ActionResult Index()
        {
            List<SessionCartProduct> SessionCart;
            if (Session["shoppingCart"] != null)
            {
                SessionCart = (List<SessionCartProduct>)Session["shoppingCart"];
            }
            else
            {
                SessionCart = new List<SessionCartProduct>();
            }
            return View(SessionCart);
        }
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
                    scp.Price = product.Price;
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
                scp.Price = product.Price;
                SessionCart.Add(scp);
            }
            Session["shoppingCart"] = SessionCart;
            return RedirectToAction("Index","Home");
        }
        public ActionResult Increase(int? id)
        {
            List<SessionCartProduct> SessionCart = (List<SessionCartProduct>)Session["shoppingCart"];

            for (int i = 0; i < SessionCart.Count; i++)
            {
                if (SessionCart[i].Product_ID == id)
                {
                    SessionCart[i].Quantity += 1;
                }
            }
            Session["shoppingCart"] = SessionCart;
            return RedirectToAction("Index");
        }
        public ActionResult Decrease(int? id)
        {
            List<SessionCartProduct> SessionCart = (List<SessionCartProduct>)Session["shoppingCart"];

            for (int i = 0; i < SessionCart.Count; i++)
            {
                if (SessionCart[i].Product_ID == id)
                {
                    if (SessionCart[i].Quantity > 1)
                    {
                        SessionCart[i].Quantity -= 1;
                    }
                    else
                    {
                        SessionCart.RemoveAt(i);
                    }
                }
            }
            Session["shoppingCart"] = SessionCart;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            List<SessionCartProduct> SessionCart = (List<SessionCartProduct>)Session["shoppingCart"];
            for (int i = 0; i < SessionCart.Count; i++)
            {
                if (SessionCart[i].Product_ID == id)
                {
                    SessionCart.RemoveAt(i);
                }
            }
            Session["shoppingCart"] = SessionCart;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Pay()
        {
            List<SessionCartProduct> SessionCart = new List<SessionCartProduct>();
            decimal toplam = 0;

            if (Session["shoppingCart"] != null)
            {
                SessionCart = (List<SessionCartProduct>)Session["shoppingCart"];
                toplam = SessionCart.Sum(x => x.Quantity * x.Price);
            }

            ViewBag.Total = toplam;
            return View();
        }

        [HttpPost]
        public ActionResult Pay(string CardNumber, string name, string ReqM, string ReqY, string CCV)
        {
            List<SessionCartProduct> SessionCart = new List<SessionCartProduct>();
            decimal toplam = 0;

            if (Session["shoppingCart"] != null)
            {
                SessionCart = (List<SessionCartProduct>)Session["shoppingCart"];
                toplam = SessionCart.Sum(x => x.Quantity * x.Price);
            }
            try
            {
                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri("https://localhost:44397/API/TestPay");
                    client.BaseAddress = new Uri("https://localhost:44397/API/Pay");

                    MerchandAPIM mapim = new MerchandAPIM();
                    mapim.CardNumber = CardNumber;
                    mapim.ExpMonth = Convert.ToInt32(ReqM);
                    mapim.ExpYear = Convert.ToInt32(ReqY);
                    mapim.CCV = CCV;
                    mapim.Price = toplam;
                    mapim.MerchandID = "7854158";
                    mapim.Password = "A789C";

                    //HTTP POST
                    var posttask = client.PostAsJsonAsync<MerchandAPIM>("Pay", mapim);
                    posttask.Wait();//Api Çalıştırıldı
                    var result = posttask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var strinResp = result.Content.ReadAsStringAsync();
                        if (strinResp.Result == "\"210\"")
                        {
                            return RedirectToAction("PaymentSuccess");
                        }
                        else if(strinResp.Result == "\"900\"")
                        {
                            ViewBag.message = "Ödeme Sistem Hatası. Lütfen daha sonra tekrar deneyiniz. Merchand Bulunamadı";
                        }
                        else if (strinResp.Result == "\"800\"")
                        {
                            ViewBag.message = "Ödeme Sistem Hatası. Lütfen daha sonra tekrar deneyiniz. Pos Sistemi kapalı";
                        }
                        else if (strinResp.Result == "\"700\"")
                        {
                            ViewBag.message = "Banka Mesajı = Kart Bulunamadı";
                        }
                        else if (strinResp.Result == "\"600\"")
                        {
                            ViewBag.message = "Banka Mesajı =Kart Sonkullanma Tarihini Kontrol ediniz";
                        }
                        else if (strinResp.Result == "\"505\"")
                        {
                            ViewBag.message = "Banka Mesajı = CCV Kontrol ediniz";
                        }
                        else if (strinResp.Result == "\"410\"")
                        {
                            ViewBag.message = "Banka Mesajı = Kart Bakiyesi yetersiz";
                        }
                        else if (strinResp.Result == "\"300\"")
                        {
                            ViewBag.message = "Banka Mesajı = Bir Hata oluştu";
                        }
                    }
                }
            }
            catch
            {

            }
            return View();
        }
    }
}