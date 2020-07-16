namespace Audiofile.Models
{
    public class PozycjaZamowienia
    {
        public int PozycjaZamowieniaId { get; set; }
        public int ZamowienieID { get; set; }
        public int UrzadzenieId { get; set; }
        public int Ilosc { get; set; }
        public decimal CennaZakupu { get; set; }

        public virtual Urzadzenie urzadzenie { get; set; }
        public virtual  Zamowienie zamowienie { get; set; }


    }
}