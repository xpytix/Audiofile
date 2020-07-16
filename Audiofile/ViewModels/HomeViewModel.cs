using Audiofile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiofile.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Kategoria> Kategorie { get; set; }
        public IEnumerable<Urzadzenie> Nowosci { get; set; }
    }
}