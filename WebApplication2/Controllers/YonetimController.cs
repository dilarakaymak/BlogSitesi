using System;
using System.Collections.Generic;
using System.Configuration;
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
            if (makale != null)
            {
                Kulllanici aktif = Session["Kullanici"] as Kulllanici; 
                makale.YayimTarihi = DateTime.Now;
                makale.MakaleTypeID = 1;
                makale.YazarID = aktif.id;
                makale.KapakResimID = ResimKaydet(Resim);
            }
            return View();
        }

        private int ResimKaydet(HttpPostedFileBase resim)
        {
            int kucukWidght = Convert.ToInt32(ConfigurationManager.AppSettings["kw"]);
            int kucukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["kh"]);
            int ortaWidght = Convert.ToInt32(ConfigurationManager.AppSettings["ow"]);
            int ortaHeight = Convert.ToInt32(ConfigurationManager.AppSettings["oh"]);
            int buyukWidght = Convert.ToInt32(ConfigurationManager.AppSettings["bw"]);
            int buyukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["bh"]);

        }
    }   
}