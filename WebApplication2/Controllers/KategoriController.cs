using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        B301_BlogEntities context = new B301_BlogEntities();
        public ActionResult Index(int id)
        {
          return View(id);
        }

        public ActionResult MakaleListele(int id)
        {
            var data = context.Makale.Where(x => x.KategoriID == id);
            return View("MakaleListele", data);
        }

    }
}