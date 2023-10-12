using PROJETAKİP.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
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
            int projesayisi = db.personelProjeleris.Count();
            ViewBag.projesayisi = projesayisi;

            int tamamlanmisproje = db.personelProjeleris.Where(p => p.TamamlanmaOrani == 100).Count();
            ViewBag.tamamlanmisproje = tamamlanmisproje;

            var tamamlanmamisproje = db.personelProjeleris.Where(P => P.TamamlanmaDurumu == false).Count();
            ViewBag.tamamlanmamisproje = tamamlanmamisproje;

            var yuksekoncelikli = db.personelProjeleris.Where(p => p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.yuksekoncelikli = yuksekoncelikli;


            var ortaoncelikli = db.personelProjeleris.Where(p => p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.ortaoncelikli = ortaoncelikli;

            var dusukoncelikli = db.personelProjeleris.Where(p => p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.dusukoncelikli = dusukoncelikli;

            var basariliveyuksek = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.basariliveyuksek = basariliveyuksek;

            var basariliveorta = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.basariliveorta = basariliveorta;

            var basarilivedusuk = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.basarilivedusuk = basarilivedusuk;


            var tamamlanmamisProje = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == false).Count();
            ViewBag.tamamlanmamisProje = tamamlanmamisProje;

            var personelprojelistesi = db.personelProjeleris.ToList();
            var personeltamamlanmisprojesayisi = new Dictionary<int, int>();//personelId - tamamlanmışperoje sayısı çifttlerini tutmak için 

            foreach (var personel in db.personelBilgileris.ToList())
            {
                int tamamalanmisprojesayisi = 0;
                foreach (var proje in personel.PersonelProjeleris)
                {
                    if (proje.TamamlanmaDurumu==true)
                    {
                        tamamalanmisprojesayisi++;
                    }
                }
                personeltamamlanmisprojesayisi[personel.PersonelBilgiId] = tamamalanmisprojesayisi;
            }

            return View();
        }
    }
}