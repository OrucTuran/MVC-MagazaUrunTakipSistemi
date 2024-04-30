using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunTakip.Models.Entitiy;

namespace MagazaUrunTakip.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var satislar = db.TblSatislar.ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            //urunler
            List<SelectListItem> urun = (from x in db.TblUrunler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Ad + " " + "(" + x.SatisFiyat + ")" + " " + "₺",
                                             Value = x.ID.ToString()
                                         }).ToList();
            ViewBag.dropUrun = urun;

            //musteriler
            List<SelectListItem> personel = (from x in db.TblPersonel.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = $"{x.Ad} {x.Soyad} ({x.Departman})",
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.dropPersonel = personel;

            //musteriler
            List<SelectListItem> musteri = (from x in db.TblMusteri.ToList()
                                            select new SelectListItem
                                            {
                                                Text = $"{x.Ad} {x.Soyad}",
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.dropMusteri = musteri;

            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TblSatislar p)
        {
            var urun = db.TblUrunler.Where(x => x.ID == p.TblUrunler.ID).FirstOrDefault();
            var musteri = db.TblMusteri.Where(x => x.ID == p.TblMusteri.ID).FirstOrDefault();
            var personel = db.TblPersonel.Where(x => x.ID == p.TblPersonel.ID).FirstOrDefault();
            p.TblUrunler = urun;
            p.TblMusteri = musteri;
            p.TblPersonel = personel;
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblSatislar.Add(p);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}