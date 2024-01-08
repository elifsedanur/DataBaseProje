using eTicaretProje.Entity;
using eTicaretProje.Identity;
using eTicaretProje.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTicaretProje.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();

        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);

        }

        [Authorize]
        public ActionResult Index()
        {
            var userName = User.Identity.GetUserName();
            var orders = db.Orders
                .Where(i => i.UserName == userName)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total,
                    PaymentMethod = i.PaymentMethod
                }).OrderByDescending(i=> i.OrderDate).ToList();

            return View(orders);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt işlemleri
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;

                IdentityResult result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    //Kullanıcı oluşturuldu bir role atanabilir.
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    //ActionName,ControllerName
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası");
                }


            }


            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login işlemleri
                var user = UserManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    //var olan kullanıcıyı sisteme dahil et
                    //ApplicationCookie oluşturup kaydetme
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    //kullanıcı için cookie oluşturduk
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    //remember me işaretlenmesine bağlı cookienin ne kadar saklancağı belirlenir
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;

                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }


            }



            return View(model);
        }
        public ActionResult Logout()
        {
            //Oluşturulan cookie sistemden silinir.
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Manage()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Manage(Manage model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = UserManager.ChangePassword(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("ManageUserError", "Şifre değiştirme hatası.");
                }
            }
            return View();
        }
        [Authorize]
        public ActionResult Update()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            Update user2 = new Models.Update()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Username = user.UserName,
            };
            return View(user2);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Update(Update model)
        {
            if (ModelState.IsValid)
            {
              var user = UserManager.FindById(User.Identity.GetUserId());
                if (user != null)
                {
                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.Email = model.Email;
                    user.UserName = model.Username;
                };
                IdentityResult result = UserManager.Update(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("UpdateUserError", "Kullanıcı güncelleme hatası.");
                }
            }
            return View(model);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders
                .Where(i=> i.Id == id)
                .Select(i=> new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState =i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres=i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    Mahalle = i.Mahalle,
                    PostaKodu = i.PostaKodu,
                    OrderLines = i.OrderLines.Select(a=> new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0,47) + "..." : a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price

                    }).ToList()
                }).FirstOrDefault();
            return View(entity);
        }
    }
}

