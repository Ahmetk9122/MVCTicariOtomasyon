using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Siniflar;
namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
       [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir (int id )
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.Faturaid);
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.TeslimEden = f.TeslimEden;
            fatura.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik ()
        {
            Class2 cs = new Class2();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);

        }
    }
}