using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        B301_BlogEntities context = new B301_BlogEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MakaleListele(Guid id)
        {
            var data = context.Makale.Where(x => x.YazarID == id);
            return View("MakaleListele", data);
        }
    }
}