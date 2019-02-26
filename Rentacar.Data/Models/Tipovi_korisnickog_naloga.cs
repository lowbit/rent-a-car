using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar.Data.Models
{
    class Tipovi_korisnickog_naloga
    {
        public string Naziv { get; set; }
        public List<string> Permisije { get; set; }
        public string Opis { get; set; }

    }
}
