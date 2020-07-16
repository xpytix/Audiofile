using Audiofile.DAL;
using Audiofile.Models;
using Audiofile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Audiofile.Controllers
{
    public class HomeController : Controller
    {
        public UrzadzeniaContext db = new UrzadzeniaContext();
        // GET: Home
        public ActionResult Index()
        {
            var kategorie = db.Kategorie.ToList();
            var nowosci = db.Urzadzenia.Where(a => !a.Ukryty).OrderByDescending(a => a.DataDodania).Take(6).ToList();
            var vm = new HomeViewModel()
            {
                Kategorie = kategorie,
                Nowosci = nowosci
            };

            return View(vm);
        }
        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }

    }
}