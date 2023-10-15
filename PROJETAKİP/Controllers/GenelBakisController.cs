using PROJETAKİP.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var siraliPersonelListesi = personeltamamlanmisprojesayisi.OrderBy(x => x.Value);// tamamlanmis proje sayisina göre personelleri sirala
            var encoktamalananpersonelId = siraliPersonelListesi.First().Key;//en çok tamamlama sayısına sahip personel al
            var encoktamalananpersonel = db.personelBilgileris.FirstOrDefault(p => p.PersonelBilgiId == encoktamalananpersonelId);
            ViewBag.encoktamamlayanPersonelBilgisi = encoktamalananpersonel.AdSoyad;

            int encokprojetamamlayanpersonelprojesayisi = personeltamamlanmisprojesayisi[encoktamalananpersonelId];
            ViewBag.Encokprojetamamlayanpersonelprojesayisi = encokprojetamamlayanpersonelprojesayisi;

            return View();
        }

        public ActionResult Genelistatistik()
        {
            var personeller=db.personelProjeleris.ToList();
            var persoenlprojeleri = db.personelProjeleris.ToList();
            var tamamlananprojesayiai = new Dictionary<int, int>();
            var tamamlanmayanprojesayisi=new Dictionary<int, int>();
            var toplamprojesayisi=new Dictionary<int , int>();
            foreach (var personel in personeller)
            {
                int tamamlananproje = 0;
                int tamamlanmayanproje = 0;
                int toplamproje = 0;
                foreach (var proje in persoenlprojeleri)
                {
                    if (proje.PersonelBilgileris.Contains(personeller))
                    {
                        toplamproje++;
                        if (proje.TamamlanmaDurumu)
                        {
                            tamamlananproje++;

                        }
                        else
                        {
                                tamamlanmayanproje++;
                        }
                    }
                }
                tamamlananprojesayiai[personel.PersonelProjeId] = tamamlananproje;
                tamamlanmayanprojesayisi[personel.PersonelProjeId]= tamamlanmayanproje;
                toplamprojesayisi[personel.PersonelProjeId] = toplamproje;
            }
            return View();
        }
    }
}