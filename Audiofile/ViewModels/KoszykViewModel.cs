using Audiofile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiofile.ViewModels
{
    public class KoszykViewModel
    {
        public List<PozycjaKoszyka> PozycjeKoszyka { get; set; }

        public decimal CenaCalkowita { get; set; }
    }
}