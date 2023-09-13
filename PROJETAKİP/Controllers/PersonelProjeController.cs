using PROJETAKİP.Models.DataContext;
using PROJETAKİP.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJETAKİP.Controllers
{
    public class PersonelProjeController : Controller
    {
        ProjeTakipDBContex db=new ProjeTakipDBContex();
        // GET: PersonelProje
        public ActionResult Index()
        {
            var proje = db.personelProjeleris.ToList();
            return View(proje);
        }

        public ActionResult Create()
        {
            ViewBag.PersonelBilgiId = new SelectList(db.personelBilgileris, "PersonelBilgiId", "AdSoyad");
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonelProjeleri projeObj, int[] PersonelBilgiId)
        {
            foreach (var x in PersonelBilgiId)
            {
                projeObj.PersonelBilgileris.Add(db.personelBilgileris.Find(x));
            }
            projeObj.OlusturulmaTarihi = DateTime.Now;
            db.personelProjeleris.Add(projeObj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}