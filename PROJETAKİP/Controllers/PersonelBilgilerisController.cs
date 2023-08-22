using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROJETAKİP.Models.DataContext;
using PROJETAKİP.Models.Personel;

namespace PROJETAKİP.Controllers
{
    public class PersonelBilgilerisController : Controller
    {
        private ProjeTakipDBContex db = new ProjeTakipDBContex(); // Veri bağlantısı

       
        public ActionResult Index() // verileri listeler
        {
            return View(db.personelBilgileris.ToList());
        }

       
        public ActionResult Details(int? id) //
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelBilgileri personelBilgileri = db.personelBilgileris.Find(id);
            if (personelBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(personelBilgileri);
        }

        
        public ActionResult Create() // Kullanıcı Veri Ekleme
        {
            return View();
        }

        
        [HttpPost] 
        [ValidateAntiForgeryToken] // Bu zaralı kelimeler t,p gibi 
        public ActionResult Create(PersonelBilgileri personelBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.personelBilgileris.Add(personelBilgileri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personelBilgileri);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelBilgileri personelBilgileri = db.personelBilgileris.Find(id);
            if (personelBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(personelBilgileri);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonelBilgiId,Eposta,Sifre,Yetki,AdSoyad,TCNO,Departman,Gorev,PozisyonAciklama,TelNo,Adres,MedeniHali,YakinBilgisi,YakinTC,YakinAdSoyad,YakinTel,DogumTarihi,IseGirisTarihi")] PersonelBilgileri personelBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personelBilgileri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personelBilgileri);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelBilgileri personelBilgileri = db.personelBilgileris.Find(id);
            if (personelBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(personelBilgileri);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonelBilgileri personelBilgileri = db.personelBilgileris.Find(id);
            db.personelBilgileris.Remove(personelBilgileri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
