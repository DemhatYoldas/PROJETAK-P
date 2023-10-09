using PROJETAKİP.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJETAKİP.Controllers
{
    public class GenelBakisController : Controller
    {
        private ProjeTakipDBContex db = new ProjeTakipDBContex(); // Veri bağlantısı
        // GET: GenelBakis
        public ActionResult Index()
        {
            int projesayisi=db.personelProjeleris.Count();
            ViewBag.projesayisi=projesayisi;

            int tamamlanmisproje = db.personelProjeleris.Where(p => p.TamamlanmaOrani == 100).Count();
            ViewBag.tamamlanmisproje=tamamlanmisproje;

            var yuksekoncelikli = db.personelProjeleris.Where(p => p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.yuksekoncelikli=yuksekoncelikli;


            var ortaoncelikli = db.personelProjeleris.Where(p => p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.ortaoncelikli = ortaoncelikli;

            var dusukoncelikli = db.personelProjeleris.Where(p => p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.dusukoncelikli = dusukoncelikli;

            return View();
        }
    }
}