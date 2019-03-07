using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Uplate
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datum_Uplate { get; set; }
        public string Iznos_U_KM { get; set; }
        [ForeignKey("Nalog")]
        public int NalogID { get; set; }
        public Nalog Nalog { get; set; }
        [ForeignKey("Korisnik")]
        public int KorisnikID { get; set; }
        public Korisnici Korisnik {get;set;}
        [ForeignKey("Vozilo")]
        public int VoziloID { get; set; }
        public Vozila Vozilo { get; set; }

        
    }
}
