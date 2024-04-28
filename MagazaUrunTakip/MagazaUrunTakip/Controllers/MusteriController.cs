using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunTakip.Models.Entitiy;
using PagedList;
using PagedList.Mvc;

namespace MagazaUrunTakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        DbMvcStokEntities db = new DbMvcStokEntities();

        public ActionResult Index(int sayfa=1)
        {
            //var musteriListe = db.TblMusteri.ToList();

            var musteriListe = db.TblMusteri.Where(x => x.Durum == true).ToList().ToPagedList(sayfa, 10);
            return View(musteriListe);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TblMusteri p)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(YeniMusteri));
            }
            p.Durum = true;
            db.TblMusteri.Add(p);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult MusteriSil(TblMusteri p)
        {
            var silinecekMusteri = db.TblMusteri.Find(p.ID);
            silinecekMusteri.Durum = false;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TblMusteri.Find(id);
            return View(nameof(MusteriGetir), musteri);
        }
        public ActionResult MusteriGuncelle(TblMusteri p)
        {
            var musteri = db.TblMusteri.Find(p.ID);
            musteri.Ad = p.Ad;
            musteri.Soyad = p.Soyad;
            musteri.Sehir = p.Sehir;
            musteri.Bakiye = p.Bakiye;
            musteri.Durum = p.Durum;

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}