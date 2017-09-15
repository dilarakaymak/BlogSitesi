using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        B301_BlogEntities context = new B301_BlogEntities();
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(string kullaniciAdi, string Parola)
        {
            if (System.Web.Security.Membership.ValidateUser(kullaniciAdi, Parola))
            {
                FormsAuthentication.RedirectFromLoginPage(kullaniciAdi, true);
                Guid id = (Guid)
                 System.Web.Security.Membership.GetUser(kullaniciAdi).ProviderUserKey;
                Session["Kullanici"] = context.Kulllanici.FirstOrDefault(x => x.id == id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı veya Parola Yanlış";
                return View();
            }


        }

        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayitOl(Kulllanici kullanici, HttpPostedFileBase Resim, string Parola)
        {
            try
            {
                MembershipUser user = System.Web.Security.Membership.CreateUser(kullanici.Nick, Parola, kullanici.Mail);
                kullanici.id = (Guid)user.ProviderUserKey;
                Session["Kullanici"] = kullanici;
                kullanici.ResimID = YonetimController.ResimKaydet(Resim, HttpContext);
                kullanici.KayıtTarihi = DateTime.Now;
                context.Kulllanici.Add(kullanici);
                context.SaveChanges();
                FormsAuthentication.RedirectFromLoginPage(kullanici.Nick, true);
            }

            catch (DbEntityValidationException ex)
            {
                throw;
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
    


