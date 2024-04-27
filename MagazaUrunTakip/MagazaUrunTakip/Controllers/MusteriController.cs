using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunTakip.Models.Entitiy;

namespace MagazaUrunTakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var musteriListe = db.TblMusteri.ToList();
            return View(musteriListe);
        }
    }
}