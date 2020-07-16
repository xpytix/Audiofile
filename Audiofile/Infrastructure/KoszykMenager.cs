using Audiofile.DAL;
using Audiofile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Audiofile.Infrastructure
{
    public class KoszykMenager
    {
        private UrzadzeniaContext db;
        private ISessjionMenager session;
        public KoszykMenager(ISessjionMenager session, UrzadzeniaContext db)
        {
            this.session = session;
            this.db = db;
        }
        public List<PozycjaKoszyka> PobierzKoszyk()
        {
            List<PozycjaKoszyka> koszyk;
            if(session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKlucz)==null)
            {
                koszyk = new List<PozycjaKoszyka>();
            }
            else
            {
                koszyk = session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKlucz) as List<PozycjaKoszyka>;
            }
            return koszyk;
        }
        public void DodajDoKoszyka(int urzadzenieId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Urzadzenie.UrzadzenieId == urzadzenieId);

            if(pozycjaKoszyka != null)
            {
                pozycjaKoszyka.Ilosc++;
            }
            else
            {
                var UrzadzaenieDoDodania = db.Urzadzenia.Where(k => k.UrzadzenieId == urzadzenieId).SingleOrDefault();
                if(UrzadzaenieDoDodania !=null)
                {
                    var nowaPozycjaKoszyka = new PozycjaKoszyka()
                    {
                        Urzadzenie = UrzadzaenieDoDodania,
                        Ilosc = 1,
                        Wartosc = UrzadzaenieDoDodania.CenaUrzadzenia
                    };
                    koszyk.Add(nowaPozycjaKoszyka);
                }
            }
            session.Set(Consts.KoszykSessionKlucz, koszyk);
        }
        public int UsunZKoszyka(int urzadzenieId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Urzadzenie.UrzadzenieId == urzadzenieId);
            if(pozycjaKoszyka != null)
            {
                if(pozycjaKoszyka.Ilosc > 1)
                {
                    pozycjaKoszyka.Ilosc--;
                    return pozycjaKoszyka.Ilosc;
                }
                else
                {
                    koszyk.Remove(pozycjaKoszyka);
                }
            }
            return 0;
        }
        public decimal PobierzWartoscKoszyka()
        {
            var koszyk = PobierzKoszyk();
            return koszyk.Sum(k => (k.Ilosc * k.Urzadzenie.CenaUrzadzenia));
        }
        public int PobierzIloscPozycjiKoszyka()
        {
            var koszyk = PobierzKoszyk();
            var ilosc = koszyk.Sum(k => (k.Ilosc));
            return ilosc;
        }
        public Zamowienie UtworzZamowienie(Zamowienie noweZamowienie, string userId)
        {
            var koszyk = PobierzKoszyk();
            noweZamowienie.DataDodania = DateTime.Now;
            noweZamowienie.UserId = userId;
            db.Zamowienia.Add(noweZamowienie);

            if(noweZamowienie.PozycjeZamowienia == null)
            {
                noweZamowienie.PozycjeZamowienia = new List<PozycjaZamowienia>();
                
            }
            decimal koszykWartosc = 0;
            foreach(var koszykElement in koszyk)
            {
                var nowaPozycjaZamowienia = new PozycjaZamowienia()
                {
                    UrzadzenieId = koszykElement.Urzadzenie.UrzadzenieId,
                    Ilosc = koszykElement.Ilosc,
                    CennaZakupu = koszykElement.Urzadzenie.CenaUrzadzenia
                };
                koszykWartosc += (koszykElement.Ilosc * koszykElement.Urzadzenie.CenaUrzadzenia);
                noweZamowienie.PozycjeZamowienia.Add(nowaPozycjaZamowienia);
            }
            noweZamowienie.WartoscZamownia = koszykWartosc;
            db.SaveChanges();
            return noweZamowienie;
        }
        public void PustyKoszyk()
        {
            session.Set<List<PozycjaKoszyka>>(Consts.KoszykSessionKlucz, null);
        }
    }
}