using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunTakip.Models.Entitiy;

namespace MagazaUrunTakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var urunler = db.TblUrunler.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.TblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.ID.ToString()
                                        }).ToList();
            ViewBag.drop = ktg;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TblUrunler p)
        {
            var ktg = db.TblKategori.Where(x => x.ID == p.TblKategori.ID).FirstOrDefault();
            p.TblKategori = ktg;
            db.TblUrunler.Add(p);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> ktg = (from x in db.TblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.ID.ToString()
                                        }).ToList();
            var urun = db.TblUrunler.Find(id);
            ViewBag.urunKtg = ktg;
            return View(nameof(UrunGetir), urun);
        }
        public ActionResult UrunGuncelle(TblUrunler p)
        {
            var urun = db.TblUrunler.Find(p.ID);
            urun.Ad = p.Ad;
            urun.Marka = p.Marka;
            urun.AlisFiyat = p.AlisFiyat;
            urun.SatisFiyat = p.SatisFiyat;
            urun.StokSayisi = p.StokSayisi;

            var ktg = db.TblKategori.Where(x => x.ID == p.TblKategori.ID).FirstOrDefault();
            urun.Kategori = ktg.ID;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult UrunSil(TblUrunler p)
        {
            var urunBul = db.TblUrunler.Find(p.ID);
            urunBul.Durum = false;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}