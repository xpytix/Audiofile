using NLog;
using Audiofile.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.InteropServices;

namespace Audiofile.Controllers
{
    public class UrzadzeniaController : Controller
    {
        private UrzadzeniaContext db = new UrzadzeniaContext();
        // GET: Urzadzenia
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lista(string nazwaKategori)
        {
            var kategoria = db.Kategorie.Include("Urzadzenia").Where(k => k.NazwaKategorii.ToUpper() == nazwaKategori.ToUpper()).Single();
            var urzadzenia = kategoria.Urzadzenia.ToList();
            return View(urzadzenia);
        }
        public ActionResult Szczegoly(int id)
        {
            var urzadzenie = db.Urzadzenia.Find(id);
            return View(urzadzenie);

        }
        [ChildActionOnly]
        [OutputCache(Duration =60000)]
        public ActionResult KategorieMenu(string nazwaKategori)
        {
            var kategorie = db.Kategorie.ToList();
            return PartialView("_KategorieMenu", kategorie);
        }
    }
}