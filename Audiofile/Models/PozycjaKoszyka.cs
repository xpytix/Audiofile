using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiofile.Models
{
    public class PozycjaKoszyka
    {
        public Urzadzenie Urzadzenie { get; set; }
        public int Ilosc { get; set; }
        public decimal Wartosc { get; set; }
    
    }
}