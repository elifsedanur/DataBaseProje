using eTicaretProje.Entity;
using eTicaretProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTicaretProje.Controllers
{
    public class HomeController : Controller
    {

        DataContext _context = new DataContext();
        public ActionResult Index()
        {
            var urunler = _context.Products
                .Where(i => i.IsApproved)
                .Select(i => new ProductModel
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Image = i.Image == null ? "1.jpg" : i.Image,
                    Price = i.Price,
                    Stock = i.Stock,
                    CategoryId = i.CategoryId,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    
                }).ToList();
            return View(urunler);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {

            var urunler = _context.Products
                .Where(i => i.IsApproved)
                .Select(i => new ProductModel
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Image = i.Image == null ? "1.jpg" : i.Image,
                    Price = i.Price,
                    Stock = i.Stock,
                    CategoryId = i.CategoryId,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                }).AsQueryable();
            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }
            return View(urunler.ToList());
        }
        public PartialViewResult getCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}