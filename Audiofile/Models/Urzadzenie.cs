using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Audiofile.Models
{
    public class Urzadzenie
    {
        public int UrzadzenieId { get; set; }
        public int KategoriaId { get; set; }
        [Required(ErrorMessage ="Wprowadz nazwę kursu")]
        [StringLength(100)]
        public string NazwaUrzadzenia { get; set; }
        public string ProducentUrzadzenia { get; set; }
  
        public DateTime DataDodania { get; set; }
        [StringLength(100)]
        public string NazwaPlikuObrazka { get; set; }
        public string OpisUrzadzenia { get; set; }
        public decimal CenaUrzadzenia { get; set; }

        public bool Ukryty { get; set; }
        public string OpisSkrocony { get; set; }
        public virtual Kategoria Kategoria { get; set; }

    }
}