using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar.Data.Models
{
    class Komentari
    {
        public string Sadrzaj { get; set; }
        public DateTime Datum_objave { get; set; }
        public Korisnicki_nalog Autor { get; set; }
        public Vijesti vijest { get; set; }
    }
}
