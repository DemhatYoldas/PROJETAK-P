using PROJETAKİP.Models.DataContext;
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
            return View();
        }
    }
}