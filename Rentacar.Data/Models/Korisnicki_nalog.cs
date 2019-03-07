using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Korisnicki_nalog
    {
        public int Id { get; set; }
        public string Korsnicko_ime { get; set; }
        public string Lozinka { get; set; }
        public string Datum_prijave { get; set; }
        public virtual Tipovi_korisnickog_naloga Tip { get; set; }
        public virtual Korisnici Korisnik { get; set; }

    }
}
