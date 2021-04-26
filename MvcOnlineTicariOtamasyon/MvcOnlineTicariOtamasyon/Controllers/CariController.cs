using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtamasyon.Models.Siniflar;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        
        // GET: Cari
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.Carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id )
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
            
        }
        public ActionResult CariGuncelle(Cariler p)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Carilers.Find(p.Cariid);
            cari.CariAd = p.CariAd;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            cari.CariNo = p.CariNo;
            cari.CariAbout = p.CariAbout;
            cari.CariGorsel = p.CariGorsel;
            cari.CarsiSifre = p.CarsiSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis (int id )
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = c.Carilers.Where(x => x.Cariid == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);

        }
        public ActionResult CariListe()
        {
            var sorgu = c.Carilers.ToList();
            return View(sorgu);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}