using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class YonetimController : Controller
    {
        // GET: Yonetim
        B301_BlogEntities context = new B301_BlogEntities();
        public ActionResult Index()
        {
            ViewBag.Tip = 1;
            return View();
        }

        public ActionResult MakaleYaz()
        {
            ViewBag.Tip = 1;
            ViewBag.Kategoriler = context.Kategori.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult MakaleYaz(Makale makale,HttpPostedFileBase Resim, string etiketler)
        {
            return View();
        }
    }   
}