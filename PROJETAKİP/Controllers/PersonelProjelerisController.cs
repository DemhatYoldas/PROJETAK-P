using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROJETAKİP.Models.DataContext;
using PROJETAKİP.Models.ProjeTakip;

namespace PROJETAKİP.Controllers
{
    public class PersonelProjelerisController : Controller
    {
        private ProjeTakipDBContex db = new ProjeTakipDBContex();

        // GET: PersonelProjeleris
        public ActionResult Index()
        {
            return View(db.personelProjeleris.ToList());
        }

        // GET: PersonelProjeleris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelProjeleri personelProjeleri = db.personelProjeleris.Find(id);
            if (personelProjeleri == null)
            {
                return HttpNotFound();
            }
            return View(personelProjeleri);
        }

        // GET: PersonelProjeleris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonelProjeleris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonelProjeId,ProjeBaslik,ProjeAciklama,OlusturulmaTarihi,OncelikDurumu,TamamlanmaOrani,TamamlanmaTarihi,TamamlanmaDurumu")] PersonelProjeleri personelProjeleri)
        {
            if (ModelState.IsValid)
            {
                db.personelProjeleris.Add(personelProjeleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personelProjeleri);
        }

        // GET: PersonelProjeleris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelProjeleri personelProjeleri = db.personelProjeleris.Find(id);
            if (personelProjeleri == null)
            {
                return HttpNotFound();
            }
            return View(personelProjeleri);
        }

        // POST: PersonelProjeleris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonelProjeId,ProjeBaslik,ProjeAciklama,OlusturulmaTarihi,OncelikDurumu,TamamlanmaOrani,TamamlanmaTarihi,TamamlanmaDurumu")] PersonelProjeleri personelProjeleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personelProjeleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personelProjeleri);
        }

        // GET: PersonelProjeleris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelProjeleri personelProjeleri = db.personelProjeleris.Find(id);
            if (personelProjeleri == null)
            {
                return HttpNotFound();
            }
            return View(personelProjeleri);
        }

        // POST: PersonelProjeleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonelProjeleri personelProjeleri = db.personelProjeleris.Find(id);
            db.personelProjeleris.Remove(personelProjeleri);
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
