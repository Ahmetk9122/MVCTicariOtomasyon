using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Siniflar;
namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            //Ürünlerde sadece görülmesini istediğimiz true komutu olanları gösteren kod bloğu
            var urunler = c.Uruns.Where(x=>x.Durum==true).ToList();

            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            //BURASI ÖNEMLİ DROPDOWN YAPMAYI GÖSTERİYOR BAK SOR!!!!!
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               //value member seçtiğimiz öğenin arka planda çalışmasına yarayan kısım.
                                               //Display member müşteriye gösterilen kısım. Ysni text i
                                               Text = x.KategoriAD,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;


            //viewbag Komutunu öğren!!!1
            //viewbag dediğimiz şey kontroller tarafından view tarafına değer taşımaya kullanılır.
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil (int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               //value member seçtiğimiz öğenin arka planda çalışmasına yarayan kısım.
                                               //Display member müşteriye gösterilen kısım. Ysni text i
                                               Text = x.KategoriAD,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
        public  ActionResult UrunGuncelle(Urun p)
        {
            var urn = c.Uruns.Find(p.Urunid);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}