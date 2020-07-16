using Audiofile.DAL;
using Audiofile.Infrastructure;
using Audiofile.ViewModels;
using Audiofile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Audiofile.App_Start;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Audiofile.Controllers
{
    public class KoszykController : Controller
    {
        private KoszykMenager koszykMenager;
        private ISessjionMenager sessionMenager { get; set; }
        private UrzadzeniaContext db;
        // GET: Koszyk
        public KoszykController()
        {
            db = new UrzadzeniaContext();
            sessionMenager = new SessionMenager();
            koszykMenager = new KoszykMenager(sessionMenager, db);
        }

        public ActionResult Index()
        {
            var pozycjeKoszyka = koszykMenager.PobierzKoszyk();
            var cenaCalkowita = koszykMenager.PobierzWartoscKoszyka();
            KoszykViewModel koszykVM = new KoszykViewModel()
            {
                PozycjeKoszyka = pozycjeKoszyka,
                CenaCalkowita = cenaCalkowita
            };

            return View(koszykVM);
        }
      
    public ActionResult DodajDoKoszyka(int id)
        {
            koszykMenager.DodajDoKoszyka(id);

            return RedirectToAction("Index");
        }

        public int PobierzIlloscElementowKoszyka()
        {
            return koszykMenager.PobierzIloscPozycjiKoszyka();
        }
        public ActionResult UsunZKoszyka(int urzadzenieId)
        {
            int iloscPozycji = koszykMenager.UsunZKoszyka(urzadzenieId);
            int iloscPozycjiKoszyka = koszykMenager.PobierzIloscPozycjiKoszyka();
            decimal wartoscKoszyka = koszykMenager.PobierzWartoscKoszyka();
            var wynik = new KoszykUsuwanieViewModel
            {
                IdPozycjiUsuwanej = urzadzenieId,
                IloscPozycjiUsuwanej = iloscPozycji,
                KoszykCenaCalkowita = wartoscKoszyka,
                KoszykIloscPozycji = iloscPozycjiKoszyka
            };
            return Json(wynik);
        }
        public async Task<ActionResult> Zaplac()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var zamowienie = new Zamowienie
                {
                    Imie = user.DaneUzytkownika.Imie,
                    Nazwisko = user.DaneUzytkownika.Nazwisko,
                    Adres = user.DaneUzytkownika.Adres,
                    Miasto = user.DaneUzytkownika.Miasto,
                    KodPocztowy = user.DaneUzytkownika.KodPocztowy,
                    Email = user.DaneUzytkownika.Email,
                    Telefon = user.DaneUzytkownika.Telefon
                };
                return View(zamowienie);
            }
            else
                return RedirectToAction("Login", "Account", new { returnurl = Url.Action("Zaplac", "Koszyk") });
                    
        }

        [HttpPost]
        public async Task<ActionResult> Zaplac(Zamowienie zamowienieSzczegoly)
        {
            if (ModelState.IsValid)
            {
                // pobieramy id uzytkownika aktualnie zalogowanego
                var userId = User.Identity.GetUserId();

                // utworzenie obiektu zamowienia na podstawie tego co mamy w koszyku
                var newOrder = koszykMenager.UtworzZamowienie(zamowienieSzczegoly, userId);

                // szczegóły użytkownika - aktualizacja danych 
                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.DaneUzytkownika);
                await UserManager.UpdateAsync(user);

                // opróżnimy nasz koszyk zakupów
                koszykMenager.PustyKoszyk();

            

                return RedirectToAction("PotwierdzenieZamowienia");
            }
            else
                return View(zamowienieSzczegoly);
        }

        public ActionResult PotwierdzenieZamowienia()
        {
   
            return View();
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}






    