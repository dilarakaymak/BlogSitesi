using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class MakaleController : Controller
    {
        // GET: Makale
        B301_BlogEntities context = new B301_BlogEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TariheGoreListe(int yil, int ay)
        {
            ViewBag.yil = yil;
            ViewBag.ay = ay;
            return View();
        }

        public ActionResult MakaleListele(int yil=0, int ay=0)
        {
          
                var data = context.Makale.Where(x => x.YayimTarihi.Year == yil && x.YayimTarihi.Month == ay);
                return View("MakaleListele", data);

        }

        public ActionResult Detay(int id)
        {
            Makale mk = context.Makale.FirstOrDefault(x => x.id == id);
            return View(mk);
        }
    }
}