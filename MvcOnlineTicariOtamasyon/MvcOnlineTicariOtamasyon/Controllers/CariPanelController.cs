using MvcOnlineTicariOtamasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
         
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.mesajlars.Where(x => x.Alici == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.Cariid).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis = c.SatisHarekets.Where(x => x.Cariid == mailid).Count();
            ViewBag.toplamsatis = toplamsatis;

            //var toplamtutar = c.SatisHarekets.Where(x => x.Cariid == mailid).Sum(y => (decimal?)y.ToplamTutar).ToString();
            //ViewBag.toplamtutar = toplamtutar;
            //var toplamurun = c.SatisHarekets.Where(x => x.Cariid == mailid)?.Sum(y => y.Adet);
            //ViewBag.toplamurun = toplamurun;

            var toplamtutar = c.SatisHarekets.Where(x => x.Cariid == mailid).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.toplamtutar = toplamtutar;
            var toplamurun = c.SatisHarekets.Where(x => x.Cariid == mailid).Sum(y => (decimal?)y.Adet).ToString();
            ViewBag.toplamurun = toplamurun;
            if (toplamtutar == "0")
            {
                toplamurun = "0";
            }
            ViewBag.toplamurun = toplamurun;


            var adsoyad = c.Carilers.Where(x => x.Cariid == mailid).Select(y => y.Cariid + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var about = c.Carilers.Where(x => x.Cariid == mailid).Select(y => y.CariAbout).FirstOrDefault();
            ViewBag.about = about;
            var sehir = c.Carilers.Where(x => x.Cariid == mailid).Select(y => y.CariSehir).FirstOrDefault();
            ViewBag.sehir = sehir;
            var no = c.Carilers.Where(x => x.Cariid == mailid).Select(y => y.CariNo).FirstOrDefault();
            ViewBag.no = no;
            var ig = c.Carilers.Where(x => x.Cariid == mailid).Select(y => y.CariGorsel).FirstOrDefault();
            ViewBag.ig = ig;
            var ad = c.Carilers.Where(x => x.Cariid == mailid).Select(y => y.CariAd).FirstOrDefault();
            ViewBag.ad = ad;
            var sad = c.Carilers.Where(x => x.Cariid == mailid).Select(y => y.CariSoyad).FirstOrDefault();
            ViewBag.sad = sad;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.Cariid).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }
       
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x=>x.Alici==mail).OrderByDescending(x=>x.MesajID).ToList();
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);

        }
      

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x => x.Gönderici == mail).OrderByDescending(z => z.MesajID).ToList();
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);

        }
  
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }
   
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();
        }
     
        [HttpPost]
        public ActionResult YeniMesaj(mesajlar m)
        {

            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gönderici = mail;
            c.mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
  
        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.KargoDetays select x;
                k = k.Where(y => y.takipKodu.Contains(p));
            return View(k.ToList());
            
        }

        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
 
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult partial1()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.Cariid).FirstOrDefault();
            var caribul = c.Carilers.Find(id);
            return PartialView("partial1", caribul);
        }
        public PartialViewResult partial2()
        {
            var veriler = c.mesajlars.Where(x => x.Gönderici == "ADMIN").ToList();
            return PartialView(veriler);
        }
         public ActionResult CariBilgiGuncelle(Cariler ca)
        {
            var cari = c.Carilers.Find(ca.Cariid);
            cari.CariAd = ca.CariAd;
            cari.CariSoyad = ca.CariSoyad;
            cari.CariMail = ca.CariMail;
            cari.CariSehir = ca.CariSehir;
            cari.CariAbout = ca.CariAbout;
            cari.CarsiSifre = ca.CarsiSifre;
            cari.CariGorsel = ca.CariGorsel;
            cari.CariNo = ca.CariNo;
            c.SaveChanges();
            return RedirectToAction("Index");
            
        }
}
}