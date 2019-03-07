using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Komentari
    {
        public int Id { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime Datum_objave { get; set; }
        public virtual Korisnicki_nalog Autor { get; set; }
        public virtual Vijesti vijest { get; set; }
    }
}
