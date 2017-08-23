using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{

    public class EtiketController : Controller
    {

        B301_BlogEntities context = new B301_BlogEntities();

        public ActionResult Index(int id)
        {
            return View(id);
        }
        public ActionResult MakaleListele(int id)
        {
            var data = context.Makale.Where(x => x.Etiket.Any(me => me.id == id));
            return View("MakaleListele", data);
        }
    }
}