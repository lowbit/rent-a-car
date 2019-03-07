using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Korisnicki_nalog
    {
        [Key]
        public int Id { get; set; }
        public string Korsnicko_ime { get; set; }
        public string Lozinka { get; set; }
        public string Datum_prijave { get; set; }

        [ForeignKey("Tip")]
        public int TipId { get; set; }
        public Tipovi_korisnickog_naloga Tip { get; set; }
        [ForeignKey("Korisnik")]
        public int KorisnikId { get; set; }
        public Korisnici Korisnik { get; set; }

    }
}
