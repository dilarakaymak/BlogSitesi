using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        //B301_BlogEntities1 context = new B301_BlogEntities1();
        B301_BlogEntities context = new B301_BlogEntities();
        public ActionResult Index()
        {

            return View();
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
        public ActionResult CategoryWidgetGetir()
        {
            return View(context.Kategori.ToList());
        }

        public ActionResult PostWidgetGetir()
        {
            ViewBag.Fresh = context.Makale.OrderByDescending(x => x.YayimTarihi).Take(5);
            ViewBag.Populer = context.Makale.OrderByDescending(x => x.Goruntulenme).Take(5);
            return View();
        }

        public ActionResult TagsWidgetGetir()
        {
            var tags = context.Etiket.ToList();
            return View(tags);

        }

        public ActionResult TumMakalelerGetir()
        {
            var makaleler = context.Makale.ToList();
            return View("MakaleListele", makaleler);
        }

    }
}