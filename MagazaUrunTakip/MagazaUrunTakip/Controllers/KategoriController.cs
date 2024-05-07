using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunTakip.Models.Entitiy;

namespace MagazaUrunTakip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            List<TblKategori> kategoriler = db.TblKategori.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TblKategori p)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(YeniKategori));
            }
            db.TblKategori.Add(p);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TblKategori.Find(id);
            db.TblKategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult KategoriGetir(int id)
        {
            var guncellenecekKategori = db.TblKategori.Find(id);
            return View(nameof(KategoriGetir), guncellenecekKategori);
        }
        public ActionResult KategoriGuncelle(TblKategori p)
        {
            var kategori = db.TblKategori.Find(p.ID);
            kategori.Ad = p.Ad;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}