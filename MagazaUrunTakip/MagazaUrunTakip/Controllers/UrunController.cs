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
            var urunler = db.TblUrunler.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TblUrunler p)
        {

            return View();
        }
    }
}