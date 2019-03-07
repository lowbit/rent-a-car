using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Vijesti
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Slika { get; set; }
        public string URL { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime Datum_i_vrijeme_objave { get; set; }
        public int Ukupno_pregleda { get; set; }
        public virtual Korisnicki_nalog Autor { get; set; }
    }
}
