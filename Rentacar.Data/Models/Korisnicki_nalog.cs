using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar.Data.Models
{
    class Korisnicki_nalog
    {
        public string Korsnicko_ime { get; set; }
        public string Lozinka { get; set; }
        public string Datum_prijave { get; set; }
        public Tipovi_korisnickog_naloga Tip { get; set; }
        public Korisnici Korisnik { get; set; }

    }
}
