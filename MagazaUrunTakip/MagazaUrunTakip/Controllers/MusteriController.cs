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

            var musteriListe = db.TblMusteri.ToList().ToPagedList(sayfa, 10);
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
            var musteri = db.TblMusteri.Add(p);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}