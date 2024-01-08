using eTicaretProje.Entity;
using eTicaretProje.Identity;
using eTicaretProje.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTicaretProje.Controllers
{
    
    public class CommentController : Controller
    {
        DataContext db = new DataContext();

        [Authorize]
        // GET: Comment
        public ActionResult Index(int id)
        {
            var comment = new UserCommentModel() { ProductId = id };
            return View(comment);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Index(UserCommentModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Username != User.Identity.Name)
                {
                    TempData["message"] = "Kullanıcı Adınızı Kontrol Edin";
                    return View(model);
                }
                else
                {
                    var comment = new Comment()
                    {
                        ProductId = model.ProductId,
                        Content = model.Content,
                        CommentDate = DateTime.Now,
                        UserName = User.Identity.GetUserName(),
                    };
                    db.Comments.Add(comment);
                    db.SaveChanges();
                }
                
              
            }
            else {
               
                    ModelState.AddModelError("CommentError", "Yorum Ekleme Hatası");
                 return View(model);
            }


           
            return RedirectToAction("Details","Home", new { id = model.ProductId });
        }
        public PartialViewResult GetComments(int id)
        {
            var comment = db.Comments.Where(i => i.ProductId == id).ToList();
            return PartialView(comment);
        }
    }
}