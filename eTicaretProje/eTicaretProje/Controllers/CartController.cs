using eTicaretProje.Entity;
using eTicaretProje.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTicaretProje.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.Where(i => i.Id == Id).FirstOrDefault();
            if(product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.Where(i => i.Id == Id).FirstOrDefault();
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public ActionResult ClearTheCart()
        {
            GetCart().Clear();
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cart =(Cart) Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        [Authorize]
        public ActionResult Checkout()
        {
            var address = db.Address.Find(User.Identity.GetUserName());
            if(address == null)
            {
                return View(new ShippingDetails());
            }
            else
            {
                var shippingDetails = new ShippingDetails()
                {
                    AdresBasligi = address.AdresBasligi,
                    Adres = address.Adres,
                    Sehir = address.Sehir,
                    Semt = address.Semt,
                    Mahalle = address.Mahalle,
                    PostaKodu = address.PostaKodu,
                };
                return View(shippingDetails);
            }
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();
            if(cart.cardLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır");
            }
            else
            {
                if(ModelState.IsValid)
                {
                    //Siparişi veri tabanına kayıt et
                    //cartı sıfırla
                    var address = db.Address.Find(User.Identity.GetUserName());
                    if (address == null)
                    {
                        var adres = new Address()
                        {
                            UserName = User.Identity.GetUserName(),
                            AdresBasligi = entity.AdresBasligi,
                            Adres = entity.Adres,
                            Sehir = entity.Sehir,
                            Semt = entity.Semt,
                            Mahalle = entity.Mahalle,
                            PostaKodu = entity.PostaKodu,
                        };
                        db.Address.Add(adres);
                    }
                    else
                    {
                       if(address.AdresBasligi != entity.AdresBasligi)
                        {
                            address.AdresBasligi = entity.AdresBasligi;
                            address.Adres = entity.Adres;
                            address.Sehir = entity.Sehir;
                            address.Semt = entity.Semt;
                            address.Mahalle = entity.Mahalle;
                            address.PostaKodu = address.PostaKodu;
                            db.Entry(address).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    if(entity.PaymentMethod == EnumPaymentMethod.CreditCart)
                    {
                        if(entity.CartNumber == null || entity.CVC == null || entity.Date == null)
                        {
                            ModelState.AddModelError("PaymentError", "Kart Bilgilerinizi Girin.");
                            return View(entity);
                        }
                        var creditcart = db.CreditCarts.Find(User.Identity.GetUserName());
                        if (creditcart == null)
                        {
                            var ccard = new CreditCart()
                            {
                                UserName = User.Identity.GetUserName(),
                                CartNumber = entity.CartNumber,
                                CVC = entity.CVC,
                                Date = entity.Date,
                            };
                            db.CreditCarts.Add(ccard);
                            db.SaveChanges();

                        }
                    }
                  
                  
                    //db.Address.Add()

                    SaveOrder(cart,entity);

                    cart.Clear();
                    //return RedirectToAction("Payment",);
                    return View("Completed");
                }
                else
                {
                    return View(entity);
                }
            }
            return View();
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random().Next(111111,999999)).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.PaymentMethod = entity.PaymentMethod;

            order.UserName = User.Identity.GetUserName();
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.OrderLines = new List<OrderLine>();
            foreach(var pr in cart.cardLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.Product.Price;
                orderline.ProductId = pr.Product.Id;

                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();

        }
   
    }
}