using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
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
                makale.KapakResimID = ResimKaydet(Resim, HttpContext);
                context.Makale.Add(makale);
                context.SaveChanges();

                string[] etikets = etiketler.Split(',');
                foreach(string etiket in etikets)
                {
                    Etiket etk = context.Etiket.FirstOrDefault(x => x.Adi.ToLower() == etiket.ToLower().Trim());
                    if(etk!=null)
                    {
                    
                        etk = new Etiket();
                        etk.Adi = etiket;
                        context.Etiket.Add(etk);
                        context.SaveChanges();
                    }
                    makale.Etiket.Add(etk);
                    context.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }

        public static int ResimKaydet(HttpPostedFileBase Resim, HttpContextBase ctx)
        {
            B301_BlogEntities context = new B301_BlogEntities();
            

            int kucukWidght = Convert.ToInt32(ConfigurationManager.AppSettings["kw"]);
            int kucukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["kh"]);
            int ortaWidght = Convert.ToInt32(ConfigurationManager.AppSettings["ow"]);
            int ortaHeight = Convert.ToInt32(ConfigurationManager.AppSettings["oh"]);
            int buyukWidght = Convert.ToInt32(ConfigurationManager.AppSettings["bw"]);
            int buyukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["bh"]);

            string newName = Path.GetFileNameWithoutExtension(Resim.FileName) + Guid.NewGuid() + Path.GetExtension(Resim.FileName);

            Image orjRes = Image.FromStream(Resim.InputStream);
            Bitmap kucukRes = new Bitmap(orjRes, kucukWidght, kucukHeight);
            Bitmap ortaRes = new Bitmap(orjRes, ortaWidght, ortaHeight);
            Bitmap buyukRes = new Bitmap(orjRes);

            kucukRes.Save(ctx.Server.MapPath("~/Content/Resimler/Kucuk/" + newName));
            ortaRes.Save(ctx.Server.MapPath("~/Content/Resimler/Orta/" + newName));
            buyukRes.Save(ctx.Server.MapPath("~/Content/Resimler/Buyuk/" + newName));

            Kulllanici k = (Kulllanici)ctx.Session["Kulllanici"]; 

            Resim dbRes = new Resim();
            dbRes.Adi = Resim.FileName;
            dbRes.BuyukResimYol = "/Content/Resimler/Buyuk/" + newName;
            dbRes.OrtaResimYol = "/Content/Resimler/Orta/" + newName;
            dbRes.KucukResimYol = "/Content/Resimler/Kucuk/" + newName;

            dbRes.EklemeTarihi = DateTime.Now;
            dbRes.EkleyenID = k.id;

            context.Resim.Add(dbRes);
            context.SaveChanges();

            return dbRes.id;

            
        }

        public ActionResult Kategori()
        {
            ViewBag.Tip = 1;
            return View(context.Kategori.ToList());
        }

        public ActionResult KategoriEkle()
        {
            ViewBag.Tip = 1;
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kat)
        {
            context.Kategori.Add(kat);
            context.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public ActionResult KategoriDuzenle(int id)
        {
            ViewBag.Tip = 1;
            return View(context.Kategori.FirstOrDefault(x => x.id == id));
        }

        [HttpPost]
        public ActionResult KategoriDuzenle(Kategori kat)
        {
            context.Entry(kat).State = System.Data.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public ActionResult KategoriSil(int id)
        {
            context.Kategori.Remove(context.Kategori.FirstOrDefault(x => x.id == id));
            context.SaveChanges();
            return RedirectToAction("Kategori");
        }

    }   
}